# NABHI: El Legado de ED

![Unity Version](https://img.shields.io/badge/Unity-2021.3.13f1-black.svg?style=flat&logo=unity)
![Platform](https://img.shields.io/badge/Platform-Windows-blue.svg)
![License](https://img.shields.io/badge/License-Proprietary-red.svg)

**Videojuego 2D de plataformas y acción desarrollado en Unity**

Desarrollado por **Aristas Studios**

---

## 📖 Descripción

NABHI: El Legado de ED es un juego de plataformas 2D con elementos de acción y aventura ambientado en un mundo sci-fi. El jugador controla a ED, un personaje que debe explorar diferentes niveles, enfrentar enemigos, y desbloquear chakras (habilidades especiales) para progresar en su aventura.

### Características Principales

- ✨ Sistema de chakras con 6 habilidades únicas
- 🎮 Combate con múltiples armas y enemigos
- 🏃 Mecánicas de plataformas fluidas (salto, dash, natación, escaleras)
- 🎵 Sistema de audio dinámico con música adaptativa
- 👾 IA de enemigos con patrullaje y detección
- 🎬 Cinemáticas con Timeline y Cinemachine
- 🎨 Efectos visuales con shaders personalizados
- 💾 Sistema de guardado con PlayerPrefs

---

## 🛠️ Requisitos Técnicos

### Para Desarrollar

- **Unity:** 2021.3.13f1 LTS
- **Git:** 2.47+
- **Git LFS:** 3.5+
- **Sistema Operativo:** Windows 10/11
- **RAM:** Mínimo 8 GB (recomendado 16 GB)
- **Espacio en Disco:** ~10 GB para proyecto completo

### Assets de Terceros

- Corgi Engine (MoreMountains)
- MoreMountains Tools & Feedbacks
- TextMesh Pro
- Universal Render Pipeline (URP)
- Cinemachine

---

## 🚀 Configuración Inicial

### 1. Clonar el Repositorio

```bash
# Clonar con Git LFS
git clone https://github.com/tu-usuario/nabhi-legado-ed.git

# Entrar al proyecto
cd nabhi-legado-ed

# Descargar archivos grandes con LFS
git lfs pull
```

### 2. Abrir en Unity

1. Abrir **Unity Hub**
2. Click en **Add** → Seleccionar la carpeta del proyecto
3. Asegurarse de usar **Unity 2021.3.13f1**
4. Click en el proyecto para abrirlo

### 3. Configurar Git (Primera Vez)

```bash
# Configurar tu identidad
git config --global user.name "Tu Nombre"
git config --global user.email "tuemail@ejemplo.com"

# Verificar Git LFS
git lfs version
```

---

## 📁 Estructura del Proyecto

```
Nabhi el legado de ED2/
├── Assets/
│   ├── AssetsNabji/          # Assets principales del juego
│   │   ├── Scenes/           # Escenas del juego
│   │   ├── Scripts/          # Scripts personalizados
│   │   ├── Prefabs/          # Prefabs de personajes, enemigos, props
│   │   ├── Sprites/          # Texturas y sprites
│   │   ├── Audio/            # Música y efectos de sonido
│   │   ├── Animaciones/      # Animaciones y controladores
│   │   └── ...
│   ├── CorgiEngine/          # Framework de plataformas
│   └── ...
├── ProjectSettings/          # Configuración del proyecto Unity
├── Packages/                 # Paquetes de Unity
├── .gitignore                # Archivos ignorados por Git
├── .gitattributes            # Configuración de Git LFS
├── CLAUDE.md                 # Documentación técnica detallada
├── GIT_WORKFLOW.md           # Guía de trabajo con Git
└── README.md                 # Este archivo
```

---

## 🎮 Cómo Jugar (Build)

### Controles

**Teclado:**
- `A/D` o `←/→` - Moverse
- `Espacio` - Saltar
- `S` o `↓` - Agacharse
- `Shift` - Dash
- `Mouse Izquierdo` - Disparar

**Gamepad:**
- `Stick Izquierdo` - Moverse
- `A (Xbox) / X (PlayStation)` - Saltar
- `Button 6` - Abrir panel de habilidades
- `RT/R2` - Disparar

---

## 💻 Desarrollo

### Flujo de Trabajo Git

#### Antes de Empezar (Cada Día)

```bash
# Actualizar con los últimos cambios
git pull origin main
git lfs pull
```

#### Durante el Desarrollo

```bash
# Ver estado de cambios
git status

# Ver diferencias
git diff
```

#### Guardar Cambios

```bash
# Agregar archivos modificados
git add .

# Crear commit
git commit -m "Feature: Descripción del cambio"

# Subir al repositorio
git push origin main
```

### Convención de Commits

```
Feature: Nueva funcionalidad
Fix: Corrección de bug
Update: Actualización de sistema existente
Refactor: Refactorización sin cambio de funcionalidad
Docs: Cambios en documentación
Config: Cambios en configuración
```

### Trabajo con Ramas

```bash
# Crear nueva rama para feature
git checkout -b feature/nombre-feature

# Trabajar en la rama
git add .
git commit -m "Feature: Descripción"

# Subir rama
git push origin feature/nombre-feature

# Fusionar con main (después de revisión)
git checkout main
git merge feature/nombre-feature
```

**📚 Para más detalles, consulta [GIT_WORKFLOW.md](GIT_WORKFLOW.md)**

---

## 📚 Documentación

- **[CLAUDE.md](CLAUDE.md)** - Documentación técnica completa del proyecto
  - Arquitectura del sistema
  - Descripción de todos los scripts
  - Sistemas del juego (chakras, combate, IA, etc.)
  - Referencias de código

- **[GIT_WORKFLOW.md](GIT_WORKFLOW.md)** - Guía completa de Git y Git LFS
  - Configuración inicial
  - Comandos básicos y avanzados
  - Trabajo en equipo
  - Resolución de problemas
  - Buenas prácticas

---

## 🎯 Roadmap

### ✅ Completado

- [x] Sistema de movimiento del personaje
- [x] Sistema de chakras básico (6 tipos)
- [x] Combate básico con armas
- [x] Enemigos básicos y IA
- [x] Sistema de jefes con boss zones
- [x] 3 niveles jugables
- [x] Menús y UI completos
- [x] Sistema de audio

### 🚧 En Desarrollo

- [ ] Chakras Fuerza, Velocidad y Gravedad (funcionalidad)
- [ ] Más tipos de enemigos
- [ ] Sistema de economía/tienda
- [ ] Niveles adicionales
- [ ] Sistema de logros

### 📋 Planeado

- [ ] Sistema de skins
- [ ] Inventario expandido
- [ ] Sistema de misiones
- [ ] Modo multijugador local
- [ ] Optimización para otras plataformas

---

## 🐛 Reporte de Bugs

Si encuentras un bug:

1. Verifica que no esté ya reportado en Issues
2. Crea un nuevo Issue con:
   - Título descriptivo
   - Pasos para reproducir
   - Comportamiento esperado vs actual
   - Capturas de pantalla (si aplica)
   - Versión de Unity y sistema operativo

---

## 🤝 Contribuir

### Para Miembros del Equipo

1. Crear una rama para tu feature: `git checkout -b feature/nombre`
2. Hacer commits descriptivos
3. Probar en Unity antes de push
4. Hacer pull request o merge según el flujo del equipo
5. Actualizar documentación si es necesario

### Reglas de Código

- Usar PascalCase para clases y métodos públicos
- Usar camelCase para variables privadas
- Comentar código complejo
- Mantener scripts organizados por funcionalidad
- No hacer commit de archivos temporales (Library/, Temp/, etc.)

---

## 📝 Licencia

**Propietario:** Aristas Studios

Este proyecto es privado y propietario. Todos los derechos reservados.

---

## 👥 Equipo

**Aristas Studios**

- Desarrollo
- Arte
- Diseño de niveles
- Audio

---

## 📞 Contacto

Para preguntas sobre el proyecto, contactar a:
- **Email:** [correo del equipo]
- **Discord:** [servidor del equipo]

---

## 🙏 Agradecimientos

- **MoreMountains** por Corgi Engine
- **Unity Technologies** por el motor y herramientas
- Asset Store creators por los assets utilizados

---

## 📊 Estado del Proyecto

![Status](https://img.shields.io/badge/Status-En%20Desarrollo-yellow.svg)
![Build](https://img.shields.io/badge/Build-Passing-brightgreen.svg)

**Última actualización:** 2025-09-30

---

**¡Gracias por ser parte del desarrollo de NABHI: El Legado de ED!** 🎮✨
