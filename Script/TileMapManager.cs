using Godot;
using System;
using Godot.Collections;

public partial class TileMapManager : TileMap
{
	[Export]
    private Dictionary<String, PackedScene> interactiveNodes;

	private Camera2D camera;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ReplaceTiles();
        camera = GetNode<Camera2D>("../Player/Camera2D");
		Rect2I mapLimits = GetUsedRect();
		Vector2I cellSize = TileSet.TileSize;
		camera.LimitLeft = mapLimits.Position.X * cellSize.X;
		camera.LimitRight = mapLimits.End.X * cellSize.X;
		camera.LimitTop = mapLimits.Position.Y * cellSize.Y;
		camera.LimitBottom = mapLimits.End.Y * cellSize.Y;
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void ReplaceTiles()
	{
		Array<Vector2I> used_cells = GetUsedCells(0);
		Vector2I tileSize = TileSet.TileSize;
		foreach(Vector2I pos in used_cells)
		{
			String tile_name = GetTileName(pos);
			if(interactiveNodes.ContainsKey(tile_name))
			{
				PackedScene packedScene = interactiveNodes[tile_name];
				Node2D node = packedScene.Instantiate<Node2D>();
				node.Position = new Vector2((pos.X + 0.5f) * tileSize.X, (pos.Y + 0.5f) * tileSize.Y);
				AddChild(node);
				SetCell(0, pos, -1);
			}
		}
	}

	private String GetTileName(Vector2I tile_pos)
	{
		
		TileData tile_data = GetCellTileData(0, tile_pos);
		if(tile_data.TerrainSet == -1)
		{
			return "";
		}
		return TileSet.GetTerrainName(tile_data.TerrainSet, tile_data.Terrain);
	}
}
