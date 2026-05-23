# SimStudio

![version](https://img.shields.io/badge/version-v0.9.0--pre-orange)
![platform](https://img.shields.io/badge/platform-Windows-blue)
![license](https://img.shields.io/badge/license-GPLv3-green)

SimStudio is an educational simulation environment designed for visualization, experimentation and training with formal computational models.

The original project was created in 2009 as part of a bachelor's thesis. This repository contains a modernized and extended version of the original system focused on improving usability, maintainability and extensibility, while also introducing training and gamification-oriented functionality.

## Features

### Simulation environment

SimStudio provides:
- graphical creation of computational models,
- state and transition function editing,
- step-by-step and automatic simulation,
- visualization of computation progress,
- multiple transition function formats,
- formal specification export,
- syntax highlighting and simple editor utilities.

### Supported computational models

- Finite Automata (FA),
- Pushdown Automata (PDA),
- Turing Machines (TM),
- Abacus Machine,
- Random Access Machine.

### Training environment

The integrated training environment provides:
- XML-based task sets,
- configurable verification methods,
- automatic test word generation,
- MathJax-based mathematical task specifications,
- support for embedded reference models,
- visual verification result panels,
- custom task set loading.

### Supported verification methods

- regular expressions,
- mathematical formulas,
- reference automata,
- custom test cases.

### Examples

SimStudio also supports:
- XML-based example sets,
- example and demonstration tasks,

## Supported file formats

Native SimStudio formats:
- `.fa`
- `.pa`
- `.tm`

Partial support:
- `.jff`

## Technologies

The project is implemented using:
- C#,
- .NET Framework 4.8.1,
- Windows Forms.

## Running the project

SimStudio is currently designed for the Windows operating system.

1. Clone the repository:

```bash
git clone https://github.com/Darkom-svg/SimStudio_FEI
```

2. Open the solution in a compatible IDE:
- Visual Studio
- JetBrains Rider

3. Build and run the project as a standard .NET Framework application.

## Project status

The project currently represents a modernized continuation of the original SimStudio system.

Current development is focused mainly on:
- codebase modernization,
- UI improvements,
- source code refactoring,
- training environment expansion,
- verification system improvements,
- gamification-oriented functionality.

## Known limitations

- TM task verification is not yet implemented,
- recursive generation of verification words may become computationally expensive for large alphabets,
- limited MathJax support for advanced mathematical constructs,
- partial JFLAP compatibility.

## License

This project is licensed under the GNU GPL v3 license.

See the `LICENSE` file for more information.
