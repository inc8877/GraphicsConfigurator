# GraphicsConfigurator

API for managing URP asset parameters, including hacking of parameters that are forbidden to change.

## Table of Contents

- [GraphicsConfigurator](#graphicsconfigurator)
  - [Table of Contents](#table-of-contents)
  - [Download](#download)
  - [How to use](#how-to-use)
  - [Installation](#installation)
    - [Install via OpenUPM](#install-via-openupm)
    - [Install via Git URL](#install-via-git-url)
    - [Include GraphicsConfigurator `.dll` into the project](#include-graphicsconfigurator-dll-into-the-project)
  - [Examples](#examples)
  - [Tested devices](#tested-devices)
  - [Known issues](#known-issues)

<details><summary>Problem</summary>
<p>

Unity closed access to change important parameters such as shadows casting, shadow resolution, lighting modes, etc.

If you want to give the user the ability to customize the resolution of shadows, then the suggestion from unit sounds like this: ***"create multiple assets and rearrange them"***

If you follow this way, you will have to create hundreds of pipeline assets to give users the ability to customize the graphics settings.

At the moment the Unity dev team does not disclose the reasons why they closed the ability to change many important parameters.
</p>
</details>

<details><summary>Solution</summary>
<p>
Create a wrapper to bypass the restrictions to modify private parameters.
</p>
</details>

## Download

|      URP       |                                        LINK                                         |
| :------------: | :---------------------------------------------------------------------------------: |
|     11.0.0     | [:arrow_down:](https://github.com/inc8877/GraphicsConfigurator/releases/tag/v1.1.0) |
| 10.3.1, 10.3.2 | [:arrow_down:](https://github.com/inc8877/GraphicsConfigurator/releases/tag/v1.0.0) |

## How to use

1. Add wrapper to your project ([installation](#installation))
2. Include wrapper library in code
3. Change any parameters of the URP Asset in one line. In the bag :clap:

## Installation

### Install via OpenUPM

The package is available on the [openupm](https://openupm.com) registry. It's recommended to install it via [openupm-cli](https://github.com/openupm/openupm-cli).

```c#
openupm add com.inc8877.graphicsconfigurator
```

### Install via Git URL

To install this package, you need to edit your Unity project's `Packages/manifest.json` and add this repository as a dependency. You can also specify the commit hash or tag like this:

```c#
{
  "dependencies": {
    "com.inc8877.graphicsconfigurator": "https://github.com/inc8877/GraphicsConfigurator.git",
   }
}
```

### Include GraphicsConfigurator `.dll` into the project

Add `.dll` to your project, you can find it in [every release](https://github.com/inc8877/GraphicsConfigurator/releases). You can find a suitable version [here](#download)

## Examples

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

## Tested devices

|    CPU    |         GPU         |       OS       | Graphics API | Backend | .Net  |
| :-------: | :-----------------: | :------------: | :----------: | :-----: | :---: |
|  SD 855   |     Adreno 640      | Android 10.3.8 |    Vulkan    | IL2CPP  |  4.x  |
|  SD 845   |     Adreno 630      | Android 10.3.7 |    Vulkan    | IL2CPP  |  4.x  |
| i7 6700HQ | AMD Randeon Pro 450 |  macOS 11.2.1  |    Metal     | IL2CPP  |  4.x  |

## Known issues

- When there is a change in the additional light rendering mode with the display of the target asset in the inspector,
  then the mode changes briefly, after which it has the parameters that were set before the change was attempted.
  This happens only in editor mode, it is not observed in assemblies.
  If, in editor mode, you try to change the rendering mode of the additional light and do not display the target asset in the inspector,
  then everything is successful.
  Presumably the problem lies in the way the asset editor works.
