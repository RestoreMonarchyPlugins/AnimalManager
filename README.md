# Animal Manager
Set up custom spawns points and modify the loot from animals.

## Features
- Modify the loot dropped by animals on death.
- Set up custom spawn points for animals with a specific radius and respawn time.

## Commands
- `/setanimalspawn <animal> [maxRadius] [respawnTime]` - Set a custom spawn point for an animal.
- `/removeanimalspawns [radius]` - Remove all custom animal spawn points in a radius.
- `/tpanimal <animal>` - Teleport to a random animal.
- `/rocket reload AnimalManager` - Reload the configuration. Not recommended with **CustomSpawns** enabled.

## Configuration
### AnimalManager.Configuration.xml
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

### AnimalSpawns.Washington.xml
```xml
<?xml version="1.0" encoding="utf-8"?>
<AnimalSpawnsConfiguration xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <AnimalSpawns>
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="527.9617" Y="58.97908" Z="592.069946" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="861.7012" Y="71.81206" Z="834.0116" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="-593.698669" Y="39.2660446" Z="868.078857" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="-669.580933" Y="74.0665741" Z="218.8468" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="-900.649353" Y="77.28775" Z="-345.900024" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="-588.231567" Y="39.54839" Z="871.519043" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="-588.367554" Y="38.7246361" Z="865.5294" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="-582.5154" Y="38.8463669" Z="868.7147" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="-588.5939" Y="38.391" Z="860.520752" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="-795.0318" Y="38.40078" Z="603.0526" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="-802.0676" Y="38.40078" Z="605.1483" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="-799.099365" Y="38.40078" Z="609.852661" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="-792.439331" Y="38.40078" Z="608.3871" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="-673.295532" Y="75.52737" Z="223.362427" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="-675.357666" Y="75.065155" Z="218.113647" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="-670.5802" Y="75.56476" Z="213.788452" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="-665.068" Y="74.5104446" Z="220.706787" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="-902.0112" Y="77.65367" Z="-341.021" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="-896.2554" Y="76.51261" Z="-343.022034" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="-901.459351" Y="77.7081451" Z="-351.319458" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="-906.6433" Y="78.82686" Z="-349.7121" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="87.73938" Y="69.83394" Z="-644.89624" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="83.62805" Y="69.6422043" Z="-641.3644" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="82.4032" Y="68.81954" Z="-647.0408" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="93.2785645" Y="70.4454651" Z="-643.812744" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="92.5802" Y="69.62181" Z="-648.8816" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="465.3108" Y="66.59284" Z="-650.931335" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="468.438477" Y="67.45911" Z="-646.6931" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="471.7765" Y="67.30369" Z="-652.4321" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="462.678223" Y="66.35037" Z="-645.908447" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="462.562866" Y="65.68098" Z="-655.642" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="450.117065" Y="48.3413162" Z="-213.849426" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="455.429565" Y="48.9203" Z="-211.6463" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="454.912" Y="49.1376038" Z="-216.657349" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="459.775635" Y="48.86454" Z="-218.41864" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="450.542847" Y="48.7832031" Z="-208.160217" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="567.344" Y="58.49245" Z="320.2898" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="565.487061" Y="59.3574448" Z="313.626343" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="572.6837" Y="58.9179764" Z="315.86792" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="572.5957" Y="57.9190063" Z="323.3855" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="577.9398" Y="57.8759842" Z="320.733643" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="866.447144" Y="72.11894" Z="830.8074" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="862.0083" Y="70.56103" Z="829.506" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="854.194336" Y="69.66251" Z="832.301636" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="868.9005" Y="71.21768" Z="826.281" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="531.8085" Y="59.3687859" Z="596.7894" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="526.284058" Y="57.679615" Z="596.4678" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="530.4453" Y="57.747818" Z="602.8273" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="535.0725" Y="58.54057" Z="605.6345" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="-69.61963" Y="56.09194" Z="561.1406" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="-64.18738" Y="56.4775467" Z="563.1422" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="-68.38922" Y="56.2058754" Z="567.1017" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="-62.9187" Y="56.3274231" Z="567.8672" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="-74.65588" Y="55.71855" Z="564.1461" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="825.6095" Y="70.38216" Z="-75.6814" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="830.2141" Y="69.78169" Z="-79.10376" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="825.000244" Y="69.717926" Z="-81.24567" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="830.5016" Y="70.9870148" Z="-72.74628" />
    <AnimalSpawn Name="Deer, Pig, Cow" AnimalId="1 4 6" X="834.9386" Y="68.7215042" Z="-82.7608" />
  </AnimalSpawns>
</AnimalSpawnsConfiguration>
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