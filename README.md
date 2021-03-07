# GraphicsConfigurator
API for managing URP parameters, including those that are closed for modification

- [Compatibility](#compatibility)
- [How to use](#how-to-use)
- [Examples](#examples)
- [Known issues](#known-issues)



<details><summary>Problem</summary>
<p>
Unity closed access to change important parameters such as shadows casting, shadow resolution, lighting modes, etc.

If you want to give the user the ability to customize the resolution of shadows, then the suggestion from unit sounds like this: ***"create multiple assets and and rearrange them"***

If you follow this way, you will have to create hundreds of pipeline assets to give users the ability to customize the graphics settings.

At the moment the Unity dev team does not disclose the reasons why they closed the ability to change many important parameters.
</p>
</details>

<details><summary>Solution</summary>
<p>
Create a wrapper to bypass the restrictions to modify private parameters.
</p>
</details>

### Compatibility
|  URP  | Compatible |
|:-----:|:-----------:|
| 10.3.2|:white_check_mark:|
| 10.3.1|:white_check_mark:|

### How to use
1. Add this repository to your project as a [submodule](https://git-scm.com/book/en/v2/Git-Tools-Submodules)
2. Include wrapper library in code
3. Change any parameters of the URP Asset in one line. In the bag :clap:

### Examples

First, plugin necessary libraries

```c#
using GraphicsConfigurator.API.URP;
using UnityEngine.Rendering.Universal;
using ShadowResolution = UnityEngine.Rendering.Universal.ShadowResolution;
```

<br>To change the active URP Asset, you need to do the following:

```c#
// ...
// code somewhere
Configuring.CurrentURPA.OpaqueDownsampling(Downsampling._4xBox);
Configuring.CurrentURPA.AntiAliasing(MsaaQuality._4x);

Configuring.CurrentURPA.MainLightMode(LightRenderingMode.PerPixel);
Configuring.CurrentURPA.MainLightShadowsCasting(true);
Configuring.CurrentURPA.MainLightShadowResolution(ShadowResolution._1024);
// ...
```

<br>If you want to work with a specific URP Asset, do it like this:

```c#
private URPAssetConfiguring URPA = new URPAssetConfiguring(target);

// ...
// code somewhere
URPA.MainLightShadowsCasting(true);
URPA.Cascade3Split(new Vector2(0.1f, 0.3f));
// ...
```

### Known issues
- When there is a change in the additional light rendering mode with the display of the target asset in the inspector,
  then the mode changes briefly, after which it has the parameters that were set before the change was attempted.
  This happens only in editor mode, it is not observed in assemblies.
  If, in editor mode, you try to change the rendering mode of the additional light and do not display the target asset in the inspector,
  then everything is successful.
  Presumably the problem lies in the way the asset editor works.