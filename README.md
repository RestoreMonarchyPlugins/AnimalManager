# Animal Manager
Set custom spawns points and modify the loot from animals.

## Features
- Modify the loot dropped by animals on death.
- Set up custom spawn points for animals with a specific radius and respawn time.

## Commands
- `/setanimalspawn <animal> [maxRadius] [respawnTime]` - Set a custom spawn point for an animal.
- `/removeanimalspawns [radius]` - Remove all custom animal spawn points in a radius.
- `/tpanimal <animal>` - Teleport to a random animal.
- `/rocket reload AnimalManager` - Reload the configuration. Not recommended with **CustomSpawns** enabled.

## Configuration
```xml
<?xml version="1.0" encoding="utf-8"?>
<AnimalManagerConfiguration xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <MessageColor>yellow</MessageColor>
  <CustomSpawns Enabled="true">
    <DefaultRespawnTime>300</DefaultRespawnTime>
    <DefaultMaxRadius>1024</DefaultMaxRadius>
    <BlockUnderwater>true</BlockUnderwater>
  </CustomSpawns>
  <Animals>
    <Animal Id="1" Name="Deer">
      <LootItems>
        <LootItem Id="514" Name="Raw Venison" Min="1" Max="3" />
        <LootItem Id="516" Name="Leather" Min="2" Max="5" />
      </LootItems>
    </Animal>
    <Animal Id="2" Name="Moose">
      <LootItems>
        <LootItem Id="514" Name="Raw Venison" Min="1" Max="3" />
        <LootItem Id="516" Name="Leather" Min="2" Max="5" />
      </LootItems>
    </Animal>
    <Animal Id="3" Name="Wolf">
      <LootItems>
        <LootItem Id="514" Name="Raw Venison" Min="1" Max="2" />
        <LootItem Id="516" Name="Leather" Min="1" Max="3" />
      </LootItems>
    </Animal>
    <Animal Id="4" Name="Pig">
      <LootItems>
        <LootItem Id="1117" Name="Pork" Min="1" Max="2" />
        <LootItem Id="516" Name="Leather" Min="1" Max="3" />
      </LootItems>
    </Animal>
    <Animal Id="5" Name="Bear">
      <LootItems>
        <LootItem Id="514" Name="Raw Venison" Min="2" Max="4" />
        <LootItem Id="516" Name="Leather" Min="3" Max="6" />
      </LootItems>
    </Animal>
    <Animal Id="6" Name="Cow">
      <LootItems>
        <LootItem Id="1120" Name="Raw Beef" Min="1" Max="2" />
        <LootItem Id="462" Name="Milk Box" Min="1" Max="2" />
        <LootItem Id="516" Name="Leather" Min="2" Max="5" />
      </LootItems>
    </Animal>
    <Animal Id="7" Name="Reindeer">
      <LootItems>
        <LootItem Id="514" Name="Raw Venison" Min="1" Max="3" />
        <LootItem Id="516" Name="Leather" Min="2" Max="5" />
      </LootItems>
    </Animal>
  </Animals>
</AnimalManagerConfiguration>
```

## Translations
```xml
<?xml version="1.0" encoding="utf-8"?>
<Translations xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Translation Id="SetAnimalSpawnSyntax" Value="/setanimalspawn &lt;animal&gt; [maxRadius] [respawnTime]" />
  <Translation Id="AnimalNotFound" Value="Animal {0} not found." />
  <Translation Id="InvalidRadius" Value="Invalid radius: {0}" />
  <Translation Id="InvalidRespawnTime" Value="Invalid respawn time: {0}" />
  <Translation Id="AnimalSpawnSet" Value="Animal spawn for {0} has been set at {1}!" />
  <Translation Id="NoAnimalSpawnsFound" Value="No animal spawns found in radius of {0}." />
  <Translation Id="AnimalSpawnRemoved" Value="Found and removed {0} animal spawns in {1}m radius." />
  <Translation Id="AnimalsNone" Value="There isn't any alive animals on the map." />
  <Translation Id="AnimalsNoneSpecific" Value="There isn't any alive {0} animals on the map." />
  <Translation Id="AnimalTeleported" Value="You have been teleported to {0} animal." />
</Translations>
```