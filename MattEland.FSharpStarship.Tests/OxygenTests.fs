module OxygenTests

open Xunit
open MattEland.FSharpStarship.Logic.World
open MattEland.FSharpStarship.Logic.Simulations

[<Fact>]
let ``Share Oxygen with two tiles should share oxygen`` () =

    // Arrange
    let originTile: Tile = {makeTile(TileType.Floor, {x=1;y=1}) with oxygen=0.7M}
    let neighborTile: Tile = {makeTile(TileType.Floor, {x=1;y=0}) with oxygen=0.5M}
    let world: GameWorld = {objects=[];tiles=[originTile; neighborTile]}

    // Act
    let finalWorld = simulateTile(originTile, world)

    // Assert
    Assert.Equal(0.6M, getGasByPos(finalWorld, originTile.pos, Gas.Oxygen))

[<Fact>]
let ``Share Oxygen with two tiles should not over-share oxygen`` () =

    // Arrange
    let originTile: Tile = {makeTile(TileType.Floor, {x=1;y=1}) with oxygen=0.7M}
    let neighborTile: Tile = {makeTile(TileType.Floor, {x=1;y=0}) with oxygen=0.68M}
    let world: GameWorld = {objects=[];tiles=[originTile; neighborTile]}

    // Act
    let finalWorld = simulateTile(originTile, world)

    // Assert
    Assert.Equal(0.69M, getGasByPos(finalWorld, originTile.pos, Gas.Oxygen))

[<Fact>]
let ``Share Oxygen with two tiles should not over-receive oxygen`` () =

    // Arrange
    let originTile: Tile = {makeTile(TileType.Floor, {x=1;y=1}) with oxygen=0.7M}
    let neighborTile: Tile = {makeTile(TileType.Floor, {x=1;y=0}) with oxygen=0.68M}
    let world: GameWorld = {objects=[];tiles=[originTile; neighborTile]}

    // Act
    let finalWorld = simulateTile(originTile, world)

    // Assert
    Assert.Equal(0.69M, getGasByPos(finalWorld, neighborTile.pos, Gas.Oxygen))

[<Fact>]
let ``Share Oxygen with two tiles should receive oxygen`` () =

    // Arrange
    let originTile: Tile = {makeTile(TileType.Floor, {x=1;y=1}) with oxygen=0.7M}
    let neighborTile: Tile = {makeTile(TileType.Floor, {x=1;y=0}) with oxygen=0.5M}
    let world: GameWorld = {objects=[];tiles=[originTile; neighborTile]}

    // Act
    let finalWorld = simulateTile(originTile, world)

    // Assert
    Assert.Equal(0.6M, getGasByPos(finalWorld, neighborTile.pos, Gas.Oxygen))

[<Fact>]
let ``Share Oxygen with three tiles should share oxygen`` () =
    
    // Arrange
    let originTile: Tile = {makeTile(TileType.Floor, {x=1;y=1}) with oxygen=0.7M}
    let neighbor1: Tile = {makeTile(TileType.Floor, {x=1;y=0}) with oxygen=0.5M}
    let neighbor2: Tile = {makeTile(TileType.Floor, {x=1;y=2}) with oxygen=0.5M}
    let world: GameWorld = {objects=[];tiles=[originTile; neighbor1; neighbor2]}
    
    // Act
    let finalWorld = simulateTile(originTile, world)
    
    // Assert
    Assert.Equal(0.6M, getGasByPos(finalWorld, originTile.pos, Gas.Oxygen))

[<Fact>]
let ``Share Oxygen with three tiles should receive oxygen`` () =
    
    // Arrange
    let originTile: Tile = {makeTile(TileType.Floor, {x=1;y=1}) with oxygen=0.7M}
    let neighbor1: Tile = {makeTile(TileType.Floor, {x=1;y=0}) with oxygen=0.5M}
    let neighbor2: Tile = {makeTile(TileType.Floor, {x=1;y=2}) with oxygen=0.5M}
    let world: GameWorld = {objects=[];tiles=[originTile; neighbor1; neighbor2]}
    
    // Act
    let finalWorld = simulateTile(originTile, world)
    
    // Assert
    Assert.Equal(0.55M, getGasByPos(finalWorld, neighbor1.pos, Gas.Oxygen))
    Assert.Equal(0.55M, getGasByPos(finalWorld, neighbor2.pos, Gas.Oxygen))

[<Fact>]
let ``Share Oxygen with four tiles should send oxygen`` () =
    
    // Arrange
    let originTile: Tile = {makeTile(TileType.Floor, {x=1;y=1}) with oxygen=0.7M}
    let neighbor1: Tile = {makeTile(TileType.Floor, {x=1;y=0}) with oxygen=0.5M}
    let neighbor2: Tile = {makeTile(TileType.Floor, {x=1;y=2}) with oxygen=0.5M}
    let neighbor3: Tile = {makeTile(TileType.Floor, {x=0;y=1}) with oxygen=0.5M}
    let world: GameWorld = {objects=[];tiles=[originTile; neighbor1; neighbor2; neighbor3]}
    
    // Act
    let finalWorld = simulateTile(originTile, world)
    
    // Assert
    Assert.Equal(0.61M, getGasByPos(finalWorld, originTile.pos, Gas.Oxygen))

[<Fact>]
let ``Share Oxygen with four tiles should receive oxygen`` () =
    
    // Arrange
    let originTile: Tile = {makeTile(TileType.Floor, {x=1;y=1}) with oxygen=0.7M}
    let neighbor1: Tile = {makeTile(TileType.Floor, {x=1;y=0}) with oxygen=0.5M}
    let neighbor2: Tile = {makeTile(TileType.Floor, {x=1;y=2}) with oxygen=0.5M}
    let neighbor3: Tile = {makeTile(TileType.Floor, {x=0;y=1}) with oxygen=0.5M}
    let world: GameWorld = {objects=[];tiles=[originTile; neighbor1; neighbor2; neighbor3]}
    
    // Act
    let finalWorld = simulateTile(originTile, world)
    
    // Assert
    Assert.Equal(0.53M, getGasByPos(finalWorld, neighbor1.pos, Gas.Oxygen))
    Assert.Equal(0.53M, getGasByPos(finalWorld, neighbor2.pos, Gas.Oxygen))
    Assert.Equal(0.53M, getGasByPos(finalWorld, neighbor3.pos, Gas.Oxygen))

[<Fact>]
let ``Oxygen should not flow into walls`` () =

    // Arrange
    let originTile: Tile = {makeTile(TileType.Floor, {x=1;y=1}) with oxygen=0.7M}
    let neighborTile: Tile = {makeTile(TileType.Wall, {x=1;y=0}) with oxygen=0M}
    let world: GameWorld = {objects=[];tiles=[originTile; neighborTile]}

    // Act
    let finalWorld = simulateTile(originTile, world)

    // Assert
    Assert.Equal(0.7M, getGasByPos(finalWorld, originTile.pos, Gas.Oxygen))
    Assert.Equal(0M, getGasByPos(finalWorld, neighborTile.pos, Gas.Oxygen))

[<Fact>]
let ``Oxygen should flow into space`` () =

    // Arrange
    let originTile: Tile = {makeTile(TileType.Floor, {x=1;y=1}) with oxygen=0.7M}
    let neighborTile: Tile = {makeTile(TileType.Space, {x=1;y=0}) with oxygen=0M}
    let world: GameWorld = {objects=[];tiles=[originTile; neighborTile]}

    // Act
    let finalWorld = simulateTile(originTile, world)

    // Assert
    Assert.Equal(0.6M, getGasByPos(finalWorld, originTile.pos, Gas.Oxygen))

    
[<Fact>]
let ``Space should not retain oxygen`` () =

    // Arrange
    let originTile: Tile = {makeTile(TileType.Floor, {x=1;y=1}) with oxygen=0.7M}
    let neighborTile: Tile = {makeTile(TileType.Space, {x=1;y=0}) with oxygen=0M}
    let world: GameWorld = {objects=[];tiles=[originTile; neighborTile]}

    // Act
    let finalWorld = simulateTile(originTile, world)

    // Assert
    Assert.Equal(0M, getGasByPos(finalWorld, neighborTile.pos, Gas.Oxygen))