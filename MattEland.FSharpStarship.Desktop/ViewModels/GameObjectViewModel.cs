﻿using MattEland.FSharpStarship.Logic;

namespace MattEland.FSharpStarship.Desktop.ViewModels
{
    public class GameObjectViewModel : WorldEntityViewModel
    {
        public GameObjectViewModel(GameObjects.GameObject obj, MainViewModel mainViewModel) : base(mainViewModel)
        {
            GameObject = obj;
        }

        public GameObjects.GameObject GameObject { get; }

        public override string ToolTip => $"{GameObject.ObjectType} ({GameObject.Pos.X}, {GameObject.Pos.Y})";

        public override int PosX => (GameObject.Pos.X * TileWidth) + (SpriteInfo.OffsetX * AppView.Zoom);
        public override int PosY => (GameObject.Pos.Y * TileHeight) + (SpriteInfo.OffsetY * AppView.Zoom);

        public override Sprites.SpriteInfo SpriteInfo => Sprites.getObjectSpriteInfo(GameObject);
    }
}