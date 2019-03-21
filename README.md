# unity-destruction

An open-source script to destroy objects realistically in Unity3D.

[Video](https://gfycat.com/EverlastingSharpBantamrooster)

## Features

- Make stuff break up on impact with other stuff!
- Make stuff break up when there's nothing underneath supporting it!
- Make stuff break up for no reason whatsoever!
- Make stuff explode!
- Make stuff make sounds when it breaks!
- Make stuff make particles when it breaks!
- Things can also be configured to only partially break apart, depending on impact velocity.
- Includes an example game where you can throw a ball at a cube. It's funner than it sounds.

## How to use

- Make an unbroken and a broken version of your object. I recommend using Blender's [cell fracture](https://duckduckgo.com/?q=blender+cell+fracture) feature.
- Add 'Destruction/Assets/Scripts/Destruction.cs' to the unbroken version.
- Mess with the settings until you get the desired breaking effect.
- For examples, see 'Destruction/main.unity'.
- Use Destruction.Break() to break things via a script, or Destruction.BreakWithExplosiveForce(float, float) to break things with explosive force via a script.
