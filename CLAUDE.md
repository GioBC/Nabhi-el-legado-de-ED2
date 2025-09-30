# NABHI: El Legado de ED - Documentación Técnica

## Información General del Proyecto

**Nombre del Proyecto:** Nabhi el legado de ED
**Desarrollador:** Aristas Studios
**Motor:** Unity 2021.3.13f1
**Versión del Proyecto:** ED2
**Tipo de Juego:** Plataformas 2D / Acción-Aventura
**Plataforma:** PC (Windows)

---

## 1. Resumen Ejecutivo

**NABHI: El Legado de ED** es un videojuego de plataformas 2D con elementos de acción y aventura. El proyecto está construido sobre el framework **Corgi Engine** de MoreMountains, aprovechando sus sistemas de movimiento, combate y gestión de personajes. El juego presenta una narrativa sci-fi con mecánicas de progresión basadas en chakras (habilidades especiales), combate con armas, sistema de salud y energía, múltiples enemigos y jefes, así como un sistema de niveles progresivos.

---

## 2. Arquitectura Técnica

### 2.1 Motor y Frameworks

- **Unity Engine:** 2021.3.13f1
- **Pipeline de Renderizado:** Universal Render Pipeline (URP)
- **Framework Principal:** Corgi Engine (MoreMountains)
- **Sistemas Adicionales:**
  - MoreMountains Tools
  - MoreMountains Feedbacks
  - MoreMountains Inventory Engine
  - TextMesh Pro
  - Cinemachine
  - Addressables System
  - Post-Processing Stack

### 2.2 Estructura del Proyecto

```
Assets/
├── AssetsNabji/              # Assets principales del juego
│   ├── Animaciones/          # Controladores y animaciones
│   ├── Audio/                # Música, SFX y mixers
│   ├── Cinematicas/          # Timelines de cinemáticas
│   ├── HUD/                  # Elementos de interfaz
│   ├── Materiales/           # Materiales y shaders
│   ├── Prefabs/              # Prefabs del juego
│   ├── Scenes/               # Escenas del juego
│   ├── Scripts/              # Scripts personalizados
│   ├── Shaders/              # Shader Graphs
│   ├── Sprites/              # Sprites y texturas
│   └── TileMaps/             # Tilemaps para niveles
├── CorgiEngine/              # Framework Corgi Engine
├── Scripts/                  # Scripts adicionales
└── [Otros Assets de Store]
```

---

## 3. Sistemas del Juego

### 3.1 Sistema de Personaje (ED - Protagonista)

**Ubicación:** `Assets/AssetsNabji/Prefabs/ED/`

**Componentes Clave:**
- **CorgiController:** Control de física y movimiento del personaje
- **Character:** Gestión de estados y habilidades del personaje
- **CharacterAbilities:** Sistema de habilidades (salto, dash, empujar, nadar, escalar)

**Animaciones:**
- Idle, Run, Jump, Fall, Dash
- Crouch, Push, Swim, Stairs
- Sistema de animación basado en Animator Controller

**Prefabs Principales:**
- `Edd.prefab` - Versión básica del personaje
- `EDD2.prefab` - Versión actualizada con todas las mecánicas

### 3.2 Sistema de Chakras (Habilidades)

**Ubicación:** `Assets/AssetsNabji/Scripts/Shakras/`

Los chakras son el sistema de progresión de habilidades del juego. Cada chakra otorga poderes especiales:

#### Tipos de Chakras:

1. **Shakra Raíz** (`ShakraRaiz.cs`)
   - Otorga fuerza para empujar objetos pesados
   - Se activa automáticamente al realizar la acción de empuje
   - Cambia el color del traje del personaje (amarillo-naranja)

2. **Shakra Sacro** (`ShakraSacro.cs`)
   - Habilidad relacionada con movimiento acuático

3. **Shakra Plexo Solar** (`ShakraPlexoSolar.cs`)
   - Relacionado con energía y resistencia

4. **Shakra Corazón** (`ShakraCorazon.cs`)
   - Sistema de vida y regeneración

5. **Shakra Garganta** (`ShakraGarganta.cs`)
   - Habilidades de comunicación/interacción

6. **Shakra Conexión** (`ShakraConexion.cs`)
   - Sistema de habilidad especial (azul cian)
   - Activa áreas tóxicas y de calor en el entorno

**Sistema de Habilidades** (`Abilities.cs`):
- Panel de selección de habilidades (botón 6 del joystick)
- Pausa el juego y deshabilita el control del personaje
- Cada habilidad modifica el color del material del traje
- Interacción con elementos ambientales (áreas tóxicas/calor)

**Persistencia:**
- Utiliza `PlayerPrefs` para guardar chakras recolectados
- Clave: `PrefShakra[NombreChakra]` (valor: 0 o 1)

### 3.3 Sistema de Combate

**Armas Disponibles:**

1. **RetroMachineGun** - Ametralladora principal del personaje
2. **AcorazadoWeapon** - Arma del enemigo Acorazado
3. **GuardianWeapon** - Arma del enemigo Guardián
4. **RobotWeapon** - Arma genérica de robots

**Proyectiles:**
- `BalaRifle.prefab` - Proyectil básico
- `2D Projectile 2/7/Guardian` - Proyectiles especiales
- Sistema de daño basado en `DamageOnTouch` de Corgi Engine

**Efectos Visuales:**
- Flashes de disparo con Sprite Sheets
- Partículas de impacto (CFXR Impact Glowing HDR)
- Sprites de muzzle flash animados

### 3.4 Sistema de Enemigos

**Ubicación:** `Assets/AssetsNabji/Prefabs/Enemigos/`

#### Enemigos Básicos:

1. **Cyborg/Coborg** (`Cyborg.prefab`)
   - Enemigo terrestre básico
   - Patrullaje simple

2. **Dron** (`dron2.prefab`)
   - IA de patrullaje aéreo (`DroneAI.cs`)
   - Detecta al jugador con radio de detección
   - Patrulla entre waypoints cuando no detecta al jugador
   - Velocidad y radio de detección configurables

3. **Torreta** (`Torreta.prefab`, `TorretaCompleta.prefab`)
   - Torretas estáticas con sistema de disparo
   - Scripts: `aim.cs`, `PathedProjectileSpawnerCannon.cs`

4. **Acorazado** (`Acorazado.prefab`)
   - Enemigo pesado con más resistencia
   - Script especial: `MuerteAcorazado.cs`

#### Enemigos Mecánicos/Trampas:

- **Sierras** (`Saw.prefab`, `PlataformasSierras.prefab`)
- **Spikes** - Púas estáticas
- **RayoElectrico** - Rayos eléctricos dañinos
- **Láser** - Sistema de rayos láser (`LaserBean.cs`)

#### Sistema de IA:

- **Waypoints.cs** - Sistema de puntos de patrullaje
- **EnemyFollower.cs** - Seguimiento del jugador
- **DroneAI.cs** - IA específica para drones (patrullaje + detección)

### 3.5 Sistema de Jefes

**Ubicación:** `Assets/AssetsNabji/Scripts/Jefes/`

**BossZone2D.cs:**
- Sistema de activación de encuentros con jefes
- Al entrar el jugador en la zona:
  - Activa el jefe
  - Levanta muros (trap walls)
  - Cambia música de nivel a música de jefe
- Al derrotar al jefe:
  - Desactiva los muros
  - Restaura la música del nivel
  - Desactiva el script

**Jefes Implementados:**
- **WarCaterpilarBoss** - Jefe tipo oruga de guerra
- **R.E.I.N.A.** - Sistema de cápsula de la Reina (`CapsulaREINA.prefab`)

### 3.6 Sistema de Niveles

**Escenas del Juego:**

#### Menús y Navegación:
- `PantallaPresentacion.unity` - Pantalla de inicio
- `MenuPrincipal.unity` - Menú principal
- `LoadingScreen.unity` - Pantalla de carga
- `Agradecimientos.unity` - Créditos

#### Cinemáticas:
- `CinematicaIntro.unity` - Cinemática de introducción
- `CinematicaGamePlay.unity` - Cinemática durante gameplay

#### Niveles Jugables:
- `Nivel-0.unity` - Nivel tutorial/inicial
- `Nivel-1.unity` - Primera zona
- `Nivel-2.unity` - Segunda zona

**Gestión de Escenas:**
- `SceneController.cs` - Carga aditiva y asíncrona de escenas
- `SceneControllerSettingsObject.cs` - Configuración de escenas persistentes
- Sistema de carga múltiple de escenas simultáneas

**Módulos de Niveles:**
- Sistema modular con prefabs (`Modulo 1` a `Modulo 17`)
- Módulos especializados: escaleras, ascensores, tubos

### 3.7 Sistema de Props e Interactivos

**Ubicación:** `Assets/AssetsNabji/Prefabs/Props/`

#### Props Interactivos:

1. **Puertas** (`Puerta_3.prefab`, `Puerta4.prefab`)
   - Animadas con apertura/cierre

2. **Ascensores** (`Ascensor.prefab`)
   - Script: `ElevatorController.cs`

3. **Plataformas Móviles** (`PlataformaMovil.prefab`)

4. **Interruptores/Palancas** (`lever_02_03.png`)
   - Script: `interruptor.cs`

5. **Portales** (`portal.prefab`)
   - Sistema de teletransportación

6. **Muros Destructibles** (`MuroDestruible.prefab`, `ParedDestruible.prefab`)

7. **Prensas** (`Prensas.prefab`)
   - Trampas mecánicas

8. **Cajas** - Objetos empujables (requiere Shakra Raíz)

#### Props Ambientales:

- **Lámparas** con efectos de luz 2D
- **Ventanas** con animación
- **Columnas** y estructura
- **Pantallas Holográficas** (`HologramScreen.png`)
- **Señalización** (`Cartel.png`, `Señal.png`)

### 3.8 Sistema de Audio

**Ubicación:** `Assets/AssetsNabji/Audio/`

#### Audio Mixer:
- `AudioMixer.mixer` - Mezclador principal con grupos:
  - Música de fondo
  - Efectos de sonido
  - UI
  - Ambiente

#### Categorías de Audio:

**Ambiente:**
- Música de nivel: "New Hope_Drums Only.wav"
- Ambientes sci-fi: "Sci Fi Ambiences - Hypnosis.wav"

**FX (Efectos de Sonido):**
- Pasos de robot
- Disparos (Blaster, Pistola, Escopeta, Granada)
- Puertas
- Pickups de salud

**HUD:**
- Sonidos de barras (Chakra, Energía)
- Coleccionables
- Economía

**UI:**
- Música de menú: "Hidden Threat.mp3"
- Sonidos de botones
- 5 pistas diferentes para pantallas de pausa

### 3.9 Sistema de UI/HUD

**Ubicación:** `Assets/AssetsNabji/HUD/`

#### Elementos del HUD:

1. **HUD Base** (`HUDBase.png`, `HUDBaseLights.png`)
   - Contenedor principal
   - Iluminación y detalles

2. **Barra de Vida**
   - `HUDHealBar.png` - Barra de relleno
   - `HUDHealContainer.png` - Contenedor
   - Sistema de feedback visual

3. **Barra de Energía/Stamina**
   - `HUDMeterBar.png` - Medidor
   - `StaminaShakraConexion.cs` - Control de stamina

4. **Panel de Habilidades**
   - Selección con joystick
   - Pausa el juego durante selección
   - Sistema de navegación: `JoystickNavigator.cs`

#### Sistema de Menús:

**MenuController.cs:**
- Navegación entre paneles
- Paneles disponibles:
  - Menú principal
  - Selección de niveles
  - Opciones (volumen, configuración)
  - Logros
  - Créditos
- Control con botón "Cancel" para retroceder
- Sistema de selección con EventSystem

**NavigationUI.cs:**
- Navegación optimizada para joystick/gamepad

### 3.10 Sistema de Diálogos e IA

**Componentes:**

1. **Diálogos NPCs** (`CuadroDialogo.prefab`, `Dialogos.prefab`)
   - Panel de información NPC con audio
   - Script: `ActivarMensajes.cs`

2. **R.E.I.N.A. (Inteligencia Artificial)**
   - `R.E.I.N.A.prefab` - Sistema de IA asistente
   - `DialogosR.E.I.N.a.prefab` - Diálogos con la IA
   - `InteligenciaArtificialPanel.prefab` - Panel de interacción
   - `DialogosAI.prefab` - Sistema general de diálogos con IA

### 3.11 Sistema de Coleccionables

**Tipos:**

1. **Circuitos de Cuarzo** (recursos)
   - `Circuito 10%.prefab` - Pequeño
   - `Circuito 50%.prefab` - Mediano
   - Efecto visual: `Circuito.prefab`

2. **Shakras** (powerups permanentes)
   - 6 tipos diferentes de chakras
   - Sistema de persistencia con PlayerPrefs
   - Script: `QuitarShakras.cs`

3. **Checkpoints** (`Checkpoints.prefab`)
   - Sistema de respawn

### 3.12 Sistema de Efectos Visuales

**Partículas:**
- `Aura ED.prefab` - Aura del personaje
- `FlashArma.prefab` - Flash de disparo
- `Heal 1.prefab` - Efecto de curación
- Efectos de impacto HDR (azul)
- Sistema CFXR de efectos

**Shaders Personalizados:**
- `LaserBean.shadergraph` - Shader de rayos láser
- `ShaderGraph_Smoke 1.shadergraph` - Efectos de humo
- Shaders de sprites con glow (`_SineGlowColor`)

**Iluminación:**
- Sistema de Light 2D de Unity
- Luces animadas (intermitentes, emergencia)
- Efectos de neón y hologramas

### 3.13 Sistema de Física y Movimiento

**Configuración del Personaje:**
- Física 2D de Unity
- CorgiController para movimiento preciso
- Detección de suelo y paredes
- Sistema de escaleras
- Sistema de natación
- Jetpack (CharacterJetpack2)

**Plataformas:**
- Plataformas móviles con waypoints
- Bandas transportadoras
- Elevadores con control manual

---

## 4. Scripts Personalizados Principales

### 4.1 Gameplay Core

| Script | Función |
|--------|---------|
| `Abilities.cs` | Sistema de habilidades de chakras |
| `GameManager.cs` | Gestor principal del juego (vacío actualmente) |
| `LevelManage.cs` | Gestión de niveles |
| `SceneController.cs` | Carga/descarga asíncrona de escenas |
| `Pause.cs` | Sistema de pausa |

### 4.2 Combat & AI

| Script | Función |
|--------|---------|
| `DroneAI.cs` | IA de patrullaje y detección de drones |
| `EnemyMovement.cs` | Movimiento básico de enemigos |
| `EnemyFollower.cs` | Seguimiento del jugador |
| `aim.cs` / `aimdrone.cs` | Sistema de apuntado |
| `BossZone2D.cs` | Sistema de encuentros con jefes |
| `DamageOnTouch2.cs` | Sistema de daño extendido |
| `KillerPlayerOnTouch.cs` | Muerte instantánea |

### 4.3 Props & Interactives

| Script | Función |
|--------|---------|
| `interruptor.cs` | Control de interruptores |
| `ElevatorController.cs` | Control de ascensores |
| `LaserBean.cs` / `Laser.cs` | Sistema de rayos láser |
| `WeaponLaserBeam.cs` | Arma de rayo láser |
| `DestroyParent.cs` | Destrucción de objetos |

### 4.4 Audio & Visuals

| Script | Función |
|--------|---------|
| `MixSounds.cs` | Mezcla de sonidos |
| `FootstepSound.cs` | Sonidos de pasos |
| `AudioZoneTrigger.cs` | Zonas de audio ambiental |
| `FadeScript.cs` | Efectos de fade |
| `Rotate.cs` / `RotarSirena.cs` | Rotación de objetos |

### 4.5 UI & Menus

| Script | Función |
|--------|---------|
| `MenuController.cs` | Control del menú principal |
| `NavigationUI.cs` | Navegación con joystick |
| `ButtonThroughKeySelection.cs` | Selección de botones por teclado |
| `Settings.cs` | Configuración del juego |

### 4.6 Chakras System

| Script | Función |
|--------|---------|
| `ShakraRaiz.cs` | Chakra de fuerza (push) |
| `ShakraSacro.cs` | Chakra sacro |
| `ShakraPlexoSolar.cs` | Chakra de energía |
| `ShakraCorazon.cs` | Chakra de vida |
| `ShakraGarganta.cs` | Chakra de garganta |
| `ShakraConexion.cs` | Chakra de conexión |
| `StaminaShakraConexion.cs` | Stamina del chakra conexión |
| `QuitarShakras.cs` | Recolección de chakras |

---

## 5. Tecnologías y Assets Externos

### 5.1 Frameworks Unity

- **Corgi Engine** - Framework de plataformas 2D
- **MoreMountains Tools** - Utilidades generales
- **MoreMountains Feedbacks** - Sistema de feedbacks visuales/audio
- **MoreMountains Inventory Engine** - Sistema de inventario

### 5.2 Rendering & Post-Processing

- **Universal Render Pipeline (URP)** - Pipeline moderno de renderizado
- **Post-Processing Stack** - Efectos visuales
- **Cinemachine** - Sistema de cámaras
- **Kino Bloom** - Efectos de bloom

### 5.3 Visual Effects

- **Cartoon FX Remaster (CFXR)** - Efectos de partículas cartoon
- **Hovl Studio Particles** - Efectos de partículas
- **Toony Colors Pro** - Shaders estilizados
- **Sprite Shaders Ultimate** - Shaders para sprites

### 5.4 Audio

- **Ultimate SFX Bundle - HD Remaster** - Biblioteca de efectos de sonido

### 5.5 UI

- **SCI-FI UI Pack Pro** - Elementos de interfaz sci-fi
- **TextMesh Pro** - Sistema de texto avanzado

### 5.6 Otros

- **Addressables** - Sistema de gestión de assets
- **PlayerPrefsEditor** - Editor de PlayerPrefs

---

## 6. Flujo del Juego

### 6.1 Inicio del Juego

1. **Pantalla de Presentación** (`PantallaPresentacion.unity`)
   - Logos de desarrollador/editor
   - Transición automática

2. **Menú Principal** (`MenuPrincipal.unity`)
   - Nuevo juego
   - Cargar partida
   - Opciones
   - Logros
   - Créditos
   - Salir

3. **Cinemática de Intro** (`CinematicaIntro.unity`)
   - Timeline con Cinemachine
   - Introducción narrativa

### 6.2 Loop de Gameplay

1. **Nivel** (Nivel-0, Nivel-1, Nivel-2)
   - Exploración de módulos
   - Combate con enemigos
   - Recolección de chakras y recursos
   - Resolución de puzzles con habilidades
   - Encuentros con jefes

2. **Checkpoints**
   - Guardar progreso
   - Punto de respawn

3. **Gate to Next Level**
   - Transición entre niveles
   - Pantalla de carga opcional

### 6.3 Sistemas de Progresión

**Chakras:**
- Se desbloquean al recolectarlos en el nivel
- Permanecen desbloqueados (PlayerPrefs)
- Permiten acceder a nuevas áreas

**Habilidades:**
- Panel de selección in-game
- Cambio dinámico de habilidad activa
- Efectos visuales en el traje del personaje

---

## 7. Configuración Técnica

### 7.1 Configuración de Unity

**Project Settings:**
- **Product Name:** Nabhi el legado de ED
- **Company Name:** Aristas Studios
- **Unity Version:** 2021.3.13f1
- **Scripting Backend:** Mono
- **API Compatibility:** .NET Standard 2.1

### 7.2 Configuración de Input

- Soporte para Keyboard + Mouse
- Soporte para Gamepad/Joystick
- Botones configurables:
  - Joystick Button 6: Panel de habilidades
  - Cancel: Retroceder en menús

### 7.3 Resolución y Pantalla

- **Default Orientation:** Landscape
- **Target Device:** Desktop/Console
- Soporte para múltiples resoluciones

### 7.4 Audio Configuration

- **Audio Mixer Groups:**
  - Master
  - Music
  - SFX
  - UI
  - Ambient

### 7.5 Layers y Tags

**Tags Principales:**
- Player
- Enemy
- Shakra
- Glow
- Difuminado
- AreaToxica
- AreaCalor

**Layers:**
- Default
- Player
- Enemies
- Platforms
- Props
- UI

---

## 8. Optimización y Performance

### 8.1 Sistemas de Optimización

- **Addressables** para carga dinámica de assets
- Carga asíncrona de escenas
- Object Pooling (implementado por Corgi Engine)
- Occlusion Culling para grandes niveles

### 8.2 Buenas Prácticas Implementadas

- Sistema modular de niveles (reutilización de prefabs)
- Separación de lógica en scripts independientes
- Uso de eventos (MMEventListener) para desacoplar sistemas
- Sistema de SceneController para gestión eficiente de escenas

---

## 9. Estado del Proyecto y Notas

### 9.1 Características Completas

- Sistema de movimiento del personaje
- Sistema de chakras/habilidades
- Combate básico
- Múltiples tipos de enemigos
- Sistema de jefes
- 3 niveles diseñados
- Menús completos
- Sistema de audio implementado
- HUD funcional

### 9.2 Sistemas en Progreso

- `GameManager.cs` está vacío (posible implementación futura)
- Algunos chakras tienen funciones vacías (ShakraFuerza, ShakraVelocidad, etc.)
- Sistema de economía/tienda comentado en MenuController

### 9.3 Assets No Utilizados

El proyecto contiene varios assets de Unity Asset Store que pueden no estar completamente integrados:
- Algunas demos de CorgiEngine
- Assets de ejemplo de packs visuales
- Scripts de demo de efectos

---

## 10. Estructura de Datos

### 10.1 PlayerPrefs (Persistencia)

| Key | Tipo | Descripción |
|-----|------|-------------|
| `PrefShakraRaiz` | int | Chakra Raíz desbloqueado (0/1) |
| `PrefShakraSacro` | int | Chakra Sacro desbloqueado (0/1) |
| `PrefShakraPlexoSolar` | int | Chakra Plexo Solar desbloqueado (0/1) |
| `PrefShakraCorazon` | int | Chakra Corazón desbloqueado (0/1) |
| `PrefShakraGarganta` | int | Chakra Garganta desbloqueado (0/1) |
| `PrefShakraConexion` | int | Chakra Conexión desbloqueado (0/1) |

### 10.2 SceneController Settings

- **Persistent Scenes:** Escenas que nunca se descargan
- **Load at Start Scenes:** Escenas cargadas al inicio
- **Scenes List:** Lista de todas las escenas del proyecto

---

## 11. Referencias de Código

### 11.1 Ejemplos de Uso

#### Activar Chakra:
```csharp
// En ShakraRaiz.cs:30-37
if (PlayerPrefs.GetInt("PrefShakraRaiz") == 1)
{
    habilitarShakraRaiz = true;
}
```

#### Sistema de Boss Zone:
```csharp
// En BossZone2D.cs:23-42
void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Player") && !bossSpawned)
    {
        boss.SetActive(true);
        // Activa muros y cambia música
    }
}
```

#### Cambio de Color de Chakra:
```csharp
// En Abilities.cs:120-136
public void ShakraConexion()
{
    for (var i = 0; i < difuminado.Length; i++)
    {
        var renderer = difuminado[i].GetComponent<SpriteRenderer>().material;
        renderer.SetColor(sineGlowColorPropertyID, ConexionColor);
    }
}
```

---

## 12. Contacto y Recursos

**Desarrollador:** Aristas Studios
**Motor:** Unity 2021.3.13f1
**Framework:** Corgi Engine by MoreMountains
**Build Output:** `NabhiBuild/`

---

## 13. Notas Finales

Este proyecto es un juego de plataformas 2D ambicioso que combina mecánicas clásicas con sistemas modernos de progresión. La arquitectura está bien estructurada gracias al uso de Corgi Engine como base, permitiendo una implementación sólida de sistemas complejos como IA, combate y progresión de habilidades.

El sistema de chakras es el elemento distintivo del juego, proporcionando tanto progresión mecánica (nuevas habilidades) como visual (efectos en el traje del personaje). La integración con assets de alta calidad de la Asset Store proporciona un acabado profesional al apartado visual y sonoro.

**Fecha de Documentación:** 2025-09-30
**Versión del Documento:** 1.0
