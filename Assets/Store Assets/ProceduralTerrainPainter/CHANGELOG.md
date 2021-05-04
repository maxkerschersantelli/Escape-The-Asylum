1.0.2

Added:
- Callback event for when a terrain is repainted (TerrainPainter.OnTerrainRepaint)
- A warning is now displayed if any terrain references have gone missing

Changed:
- Adding a new modifier now automatically selects it

Fixed:
- Texture modifier not aligning correctly if a terrain had a large negative position
- Modifier settings not drawing when Odin is installed

1.0.1

Added:
- Auto repaint option in Settings tab. Repaints a terrain when its height is modified.
- Option to refresh Vegetation Studio Pro when terrain is repainted

Changed:
- Renamed namespace to "sc.terrain.proceduralpainter" for consistency between other terrain tools

Fixed:
- Heatmap preview highlighting wrong terrain layer in some cases

1.0.0
Initial release