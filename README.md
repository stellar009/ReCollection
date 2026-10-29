# ReCollection

![Engine](https://img.shields.io/badge/Engine-Unity-black?logo=unity&logoColor=white)
![Platform](https://img.shields.io/badge/Platform-Windows-0078D6?logo=windows&logoColor=white)
![Type](https://img.shields.io/badge/Type-Game%20Jam-FF6B35)
![ShaderLab](https://img.shields.io/badge/ShaderLab-74.3%25-9E1F63)
![C%23](https://img.shields.io/badge/C%23-16.7%25-239120?logo=csharp&logoColor=white)
![HLSL](https://img.shields.io/badge/HLSL-9%25-1E90FF)
![Release](https://img.shields.io/badge/Latest-v1.1-brightgreen)
![Status](https://img.shields.io/badge/Status-Released-success)

> A Unity game jam project built around a shader-heavy visual style and a self-activating teleport-point system. ReCollection was developed under jam time constraints and iterated across three tagged releases, with a strong focus on optimized shader math and a clean, color-driven aesthetic.

---

## Screenshots

<p align="center">
  <em>Gameplay screenshots and GIFs will be added here.</em>
</p>

> Replace this block with in-game captures once available. Recommended format: a 1280×720 PNG or a short MP4/GIF loop showcasing the shader aesthetic and a teleport-point activation.

---

## Key Features

- **Shader-First Visual Style** — With ShaderLab making up nearly three-quarters of the codebase and HLSL handling the lower-level math, the game's look is driven almost entirely by custom shaders rather than off-the-shelf post-processing.
- **Optimized Shader Math** — The v1.1 release explicitly reworks the mathematical calculations behind shaders and in-game color computation, reducing per-frame cost while preserving the visual identity.
- **Self-Activating Teleport (TP) Points** — Teleport points activate themselves based on game state, removing the need for centralized update logic and keeping the per-frame cost flat as more TP points are placed in a scene.
- **Windows Build** — Shipped as a self-contained Windows build, downloadable directly from the Releases page.

---

## Optimization Deep-Dive

ReCollection is unusually shader-heavy for a jam project — 74.3% ShaderLab, 9% HLSL, only 16.7% C#. The optimization work therefore lives almost entirely in the rendering layer.

### 1. Shader Math Optimization

The v1.1 patch reworked the mathematical core of the custom shaders: per-pixel color calculations were simplified, redundant operations were folded into fewer passes, and game-color computation was moved closer to the data it depends on. The result is a measurable drop in GPU cost per frame, which matters most on integrated graphics where shader ALU is the bottleneck.

### 2. Color Computation Pipeline

Rather than recomputing colors in multiple shader stages, ReCollection funnels color decisions through a single shared path. This keeps the visual identity consistent across scenes and makes future tuning (e.g., a palette swap for a new level) a one-line change instead of a multi-shader refactor.

### 3. Self-Activating TP Point System

Teleport points in ReCollection do not rely on a central manager polling every frame. Each TP point evaluates its own activation condition and toggles its state autonomously. This pattern scales linearly with the number of TP points in a scene without inflating per-frame CPU cost, and it keeps the C# side of the codebase minimal — which is consistent with the project's shader-first architecture.

---

## Built With

| Layer            | Technology                  |
|------------------|-----------------------------|
| Engine           | Unity                       |
| Platform         | Windows                     |
| Gameplay Code    | C#                          |
| Shaders          | ShaderLab + HLSL            |
| Focus Areas      | Shader Optimization, Color Pipeline, Game-Jam Workflow |

---

## Project Structure

```
ReCollection/
├── Assets/                  # Game assets: scenes, scripts, shaders, art, audio
│   ├── Scenes/              # Unity scenes
│   ├── Scripts/             # C# gameplay code (TP point system, etc.)
│   ├── Shaders/             # ShaderLab + HLSL custom shaders
│   └── ...                  # Art, audio, prefabs, settings
├── Packages/                # Unity package manifest and dependencies
├── ProjectSettings/         # Unity project configuration (graphics, quality, input)
├── .gitattributes           # Git LFS / line-ending rules
├── .gitignore               # Unity-aware ignore rules
└── .vsconfig                # Visual Studio workspace config
```

---

## How to Play

1. **Download** the latest release build (`ReCollection.zip`, ~43 MB) from the [Releases](#releases) section below.
2. **Unzip** the downloaded archive to a folder of your choice.
3. **Run** the extracted executable.

No additional dependencies are required — the build is self-contained for Windows.

---

## Releases

ReCollection has shipped three tagged releases, progressing from beta to a stable v1.1:

| Version         | Tag    | Date          | Highlights                                                                                  |
|-----------------|--------|---------------|---------------------------------------------------------------------------------------------|
| **v1.1** (latest) | `v1.1` | Oct 1, 2026  | Added self-activation system for TP points; optimized mathematical calculations for shaders and game colors. |
| v1.0            | `v1.0` | Oct 1, 2026  | First stable build for Windows. Open call for bug reports and improvement feedback.         |
| v0.5 (Beta)     | `v0.5` | Sep 28, 2026 | Beta version of ReCollection. Initial playable build (~69 MB).                              |

> Each release ships a ready-to-play Windows build. Download the zip, extract, and run the executable.

---

## Purpose of This Project

ReCollection was built to serve three overlapping goals:

1. **Game jam entry** — a complete, shipped game developed under jam time constraints, demonstrating fast iteration and scoped execution.
2. **Personal portfolio piece** — a public showcase of shader-heavy Unity work, available at [github.com/stellar009/ReCollection](https://github.com/stellar009/ReCollection).
3. **Practical demonstration of shader optimization** — specifically the v1.1 rework of shader math and color computation, applied to a shipped title rather than a contrived demo.

---

## Roadmap

Future work being considered for ReCollection:

- [ ] Add in-game screenshots and gameplay GIFs to this README
- [ ] Mac / Linux build pipeline
- [ ] In-engine quality presets for low-end integrated GPUs
- [ ] Additional levels leveraging the existing color pipeline
- [ ] Audio pass and SFX for TP point activation
- [ ] Save system for level progression
- [ ] Post-jam postmortem write-up linked from this README

---

## Author

**stellar009** — Unity developer focused on shader work and performance-conscious game-jam builds.
GitHub: [@stellar009](https://github.com/stellar009) · Repository: [ReCollection](https://github.com/stellar009/ReCollection)

---

> *ReCollection — shader-first, jam-tested.*
