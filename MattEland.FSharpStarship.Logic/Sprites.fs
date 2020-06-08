﻿namespace MattEland.FSharpStarship.Logic

open World

module Sprites =

  type SpriteInfo = {image: string; x: int; y: int; width: int; height: int; zIndex: int}

  let private getZIndex (tileType: TileType): int =
    match tileType with
    | Wall -> 1
    | _ -> 0

  let private getTileX (tileType: TileType): int =
    match tileType with
    | Wall -> 6
    | WallLeft | WallRight -> 7
    | Floor -> 0

  let private getTileY (tileType: TileType): int =
    match tileType with
    | Wall -> 0
    | WallLeft | WallRight -> 2
    | Floor -> 11

  let getSpriteInfo (tileType: TileType): SpriteInfo =
    {
      image="tileset2.png"
      x=getTileX(tileType);
      y=getTileY(tileType);
      width=32;
      height=32;
      zIndex=getZIndex(tileType)
    }