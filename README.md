# Modeling a Starship in F#
Code for an upcoming talk on Modeling a Starship in F#. Intended as a fun introduction to the F# programming language.

## Credits

### Code
All code written by Matt Eland (@IntegerMan)

### Art

#### Tiles

Tile artwork commercially purchased from DithArt and used in open source software with permission.

Visit https://dithart.itch.io/ for more information on DithArt's assets. Artwork cannot be reused, repurposed, or redistributed without their express written consent.

#### Astronaut

Astronaut artwork found at https://grandmadebslittlebits.wordpress.com/2017/02/21/astronaut-sprite-by-pjcr/ and credited to PJCR and free for use in commercial / non-commercial work.

## Level

- [x] Create a simple 1-room space ship
- [x] Add a human actor
- [x] Create a multi-room space ship

## Graphics

- [x] Overlay mode
- [x] Overlay for Heat
- [x] Overlay for Oxygen
- [x] Overlay for Carbon Dioxide
- [ ] Overlay for Fluids
- [ ] Overlay for Electrical
- [x] Tile Graphics
- [x] Render actors
- [x] Next turn button
- [x] Render gasses as pixels based on their density
- [x] Player Graphic
- [x] Air Scrubber Graphic
- [x] Better Player Graphic

## Interaction

- [x] Simulate when next turn is clicked
- [x] Allow the player to move the human actor
- [ ] Prevent movement through walls
- [ ] Prevent movement through out of bounds
- [ ] Allow the player to destroy a wall
- [ ] Activate machines
- [ ] Restart simulation
- [x] Auto-advance simulation
- [x] Ability to pause and resume the simulation

## Environmental

- [x] Oxygen distribution
- [x] CO2 distribution
- [x] Gasses should not be able to go below 0
- [x] Obstacles prohibit gasses from flowing
- [x] Space takes in gasses, but doesn't retain it
- [x] Convert O2 to CO2 near human
- [x] Air recylclers convert CO2 to Oxygen
- [x] Allow faster equilibrium between tiles
- [ ] Simulate tile gasses iteratively and then recursively with a max number of recursions
- [ ] Gas should be displaced by closing doors
- [ ] Gas should not spawn in walls or outside
- [ ] Adapt new level to have CO2 Emitters
- [ ] Adapt new level to have Oxygen Emitters

## Power

- [ ] Power distribution
- [ ] Sparks can occur if too much water vapor
- [ ] Sparks can cause fires if there's too much oxygen
- [ ] Power Cells
- [ ] Generator
- [ ] Solar Generator
- [ ] Running machines require power
- [ ] Wires can carry power around
- [ ] Scrubbers only scrub with power

## Player Health

- [ ] Player needs oxygen
- [ ] Player needs healthy temperature range
- [ ] Player can die
- [ ] Player can heal
- [ ] Player periodically needs water
- [ ] Player periodically needs food
- [ ] Player periodically needs to use the bathroom

## Heat

- [x] Heat distribution
- [ ] Non gaseous heat distribution rules
- [ ] Fires?
- [ ] Heat expands
- [ ] Heat impacts pipes
- [ ] Heat sinks can spread heat outside the ship
- [ ] Scrubbers generate heat
- [ ] Astronauts generate heat
- [ ] Fire generates heat

## Water

- [ ] Water distribution
- [ ] Fluid Pipes
- [ ] Fluid tanks
- [ ] Water Recycling
- [ ] Water freezes if tile too cold?
- [ ] Water vapor generated by player
- [ ] Water vapor generated by drinking
- [ ] Water vapor generated by using bathroom

## Architecture

- [x] Do not use .Value (Use Option. instead)
- [x] Do not use mutable
- [x] Use upper-case field names
- [ ] Convert methods to function syntax when possible
- [x] Anything returning an option should start with try

## Performance
- [x] Switch to a DrawingVisual rendering approach
- [x] Switch to an update-based model instead of a clear / redraw model
- [x] Recycle brushes