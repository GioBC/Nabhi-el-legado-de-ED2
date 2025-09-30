# Guía de Trabajo con Git y Git LFS - Proyecto NABHI

## Índice
1. [Configuración Inicial](#configuración-inicial)
2. [Flujo de Trabajo Básico](#flujo-de-trabajo-básico)
3. [Trabajo en Equipo](#trabajo-en-equipo)
4. [Comandos Importantes](#comandos-importantes)
5. [Buenas Prácticas](#buenas-prácticas)
6. [Resolución de Problemas](#resolución-de-problemas)
7. [Git LFS - Archivos Grandes](#git-lfs---archivos-grandes)

---

## Configuración Inicial

### 1. Instalar Git y Git LFS

**Git:**
- Descargar desde: https://git-scm.com/downloads
- Instalar con las opciones por defecto

**Git LFS (Large File Storage):**
- Descargar desde: https://git-lfs.github.com/
- O instalar via: `git lfs install`

### 2. Configurar tu Identidad (PRIMERA VEZ)

```bash
# Configurar tu nombre (será visible en los commits)
git config --global user.name "Tu Nombre"

# Configurar tu email (debe coincidir con el de GitHub/GitLab)
git config --global user.email "tuemail@ejemplo.com"

# Verificar configuración
git config --list
```

### 3. Clonar el Repositorio (Si ya existe en GitHub/GitLab)

```bash
# Navegar a la carpeta donde quieres el proyecto
cd C:/Users/TuUsuario/Documents/Proyectos

# Clonar el repositorio
git clone https://github.com/tu-usuario/nabhi-legado-ed.git

# Entrar a la carpeta del proyecto
cd nabhi-legado-ed

# Git LFS descargará automáticamente los archivos grandes
git lfs pull
```

### 4. Conectar Repositorio Local con GitHub/GitLab (Si es nuevo)

```bash
# Crear repositorio en GitHub/GitLab primero (sin README ni .gitignore)
# Luego ejecutar estos comandos:

# Ya se ejecutó: git init
# Ya se ejecutó: git lfs install

# Agregar el origen remoto
git remote add origin https://github.com/tu-usuario/nabhi-legado-ed.git

# Verificar el remoto
git remote -v
```

---

## Flujo de Trabajo Básico

### Antes de Empezar a Trabajar (SIEMPRE)

```bash
# 1. Asegurarte de estar en la rama correcta
git branch

# 2. Actualizar tu copia local con los últimos cambios
git pull origin main

# 3. (Si usas LFS) Asegurar que los archivos grandes están actualizados
git lfs pull
```

### Durante el Trabajo

```bash
# Ver qué archivos has modificado
git status

# Ver los cambios específicos en los archivos
git diff

# Ver cambios en un archivo específico
git diff Assets/Scripts/MiScript.cs
```

### Guardar tus Cambios (Commit)

```bash
# 1. Agregar los archivos modificados al staging area

# Agregar un archivo específico
git add Assets/Scripts/MiScript.cs

# Agregar todos los archivos modificados en una carpeta
git add Assets/Prefabs/

# Agregar TODOS los archivos modificados (usar con precaución)
git add .

# 2. Ver qué archivos están listos para commit
git status

# 3. Crear un commit con un mensaje descriptivo
git commit -m "Añadir sistema de disparo del personaje"

# Ejemplo de mensajes de commit:
# git commit -m "Fix: Corregir bug de colisión en enemigos"
# git commit -m "Feature: Implementar chakra de conexión"
# git commit -m "Update: Mejorar IA del drone"
# git commit -m "Refactor: Optimizar sistema de audio"
```

### Subir tus Cambios al Repositorio Remoto (Push)

```bash
# Subir tus commits a la rama principal
git push origin main

# Si es tu primer push en una rama nueva
git push -u origin nombre-de-tu-rama

# Git LFS subirá automáticamente los archivos grandes
```

---

## Trabajo en Equipo

### Sistema de Ramas (Branches)

Las ramas te permiten trabajar en features sin afectar el código principal.

```bash
# Ver todas las ramas
git branch -a

# Crear una nueva rama
git branch feature/nuevo-enemigo

# Cambiar a esa rama
git checkout feature/nuevo-enemigo

# O crear y cambiar en un solo comando
git checkout -b feature/nuevo-enemigo

# Trabajar normalmente (add, commit)
git add .
git commit -m "Feature: Agregar nuevo tipo de enemigo"

# Subir la rama al repositorio remoto
git push origin feature/nuevo-enemigo

# Cuando termines, fusionar con main
git checkout main
git merge feature/nuevo-enemigo

# Eliminar la rama local (opcional)
git branch -d feature/nuevo-enemigo
```

### Convención de Nombres de Ramas

```
main                    # Rama principal (código estable)
develop                 # Rama de desarrollo (opcional)
feature/nombre          # Nueva funcionalidad
bugfix/nombre           # Corrección de bug
hotfix/nombre           # Corrección urgente
refactor/nombre         # Refactorización de código
```

### Traer Cambios de Otros Miembros (Pull)

```bash
# ANTES de empezar a trabajar cada día
git pull origin main

# Si hay conflictos, Git te avisará
# Deberás resolverlos manualmente en los archivos
```

### Resolver Conflictos

Cuando dos personas modifican el mismo archivo:

```bash
# 1. Git te avisará del conflicto al hacer pull
git pull origin main
# CONFLICT (content): Merge conflict in Assets/Scripts/Player.cs

# 2. Abrir el archivo en Unity o tu editor
# Verás marcadores así:
# <<<<<<< HEAD
# Tu código
# =======
# Código de otro compañero
# >>>>>>> origin/main

# 3. Editar el archivo para quedarte con lo correcto
# Eliminar los marcadores <<<, ===, >>>

# 4. Agregar el archivo resuelto
git add Assets/Scripts/Player.cs

# 5. Completar el merge
git commit -m "Merge: Resolver conflicto en Player.cs"

# 6. Subir los cambios
git push origin main
```

---

## Comandos Importantes

### Ver el Historial

```bash
# Ver todos los commits
git log

# Ver commits de forma compacta
git log --oneline

# Ver los últimos 5 commits
git log -5

# Ver commits con gráfico de ramas
git log --graph --oneline --all

# Ver quién modificó cada línea de un archivo
git blame Assets/Scripts/Player.cs
```

### Deshacer Cambios

```bash
# Descartar cambios NO guardados en un archivo
git checkout -- Assets/Scripts/Player.cs

# Descartar TODOS los cambios no guardados
git checkout .

# Quitar un archivo del staging area (antes de commit)
git reset Assets/Scripts/Player.cs

# Deshacer el último commit (pero mantener cambios)
git reset --soft HEAD~1

# Deshacer el último commit (y eliminar cambios)
git reset --hard HEAD~1

# Volver a un commit específico
git reset --hard abc1234
```

### Guardar Trabajo Temporal (Stash)

Útil cuando necesitas cambiar de rama pero no quieres hacer commit:

```bash
# Guardar cambios temporalmente
git stash

# Ver lista de stashes
git stash list

# Recuperar el último stash
git stash pop

# Recuperar un stash específico
git stash apply stash@{0}

# Eliminar todos los stashes
git stash clear
```

### Ver Información

```bash
# Ver estado actual
git status

# Ver diferencias
git diff

# Ver ramas
git branch -a

# Ver remotos configurados
git remote -v

# Ver archivos trackeados por Git LFS
git lfs ls-files

# Ver tamaño de los archivos LFS
git lfs ls-files -s
```

---

## Buenas Prácticas

### ✅ DO (Hacer)

1. **Hacer Pull ANTES de empezar a trabajar**
   ```bash
   git pull origin main
   ```

2. **Hacer commits pequeños y frecuentes**
   ```bash
   # Mejor hacer varios commits pequeños que uno gigante
   git commit -m "Añadir animación de salto"
   git commit -m "Ajustar velocidad del salto"
   ```

3. **Escribir mensajes de commit claros**
   ```bash
   # ✅ Bien
   git commit -m "Fix: Corregir bug de colisión con enemigos en Nivel 1"

   # ❌ Mal
   git commit -m "cambios"
   ```

4. **Usar .gitignore correctamente**
   - Ya configurado para ignorar Library/, Temp/, .vs/, etc.

5. **Hacer backup de PlayerPrefs y configuraciones locales**

6. **Probar el juego antes de hacer push**

7. **Usar Git LFS para archivos grandes**
   - Imágenes, audio, videos, modelos 3D ya están configurados

### ❌ DON'T (No Hacer)

1. **NO hacer commit de carpetas generadas:**
   - Library/
   - Temp/
   - Obj/
   - Builds/
   - .vs/

2. **NO hacer commit de archivos de proyecto de IDEs:**
   - .csproj
   - .sln
   - (Ya están en .gitignore)

3. **NO hacer `git add .` sin revisar con `git status` primero**

4. **NO hacer push sin probar localmente primero**

5. **NO trabajar directamente en main si son varios desarrolladores**
   - Usar ramas (branches)

6. **NO guardar contraseñas o claves en el código**

7. **NO modificar el historial público (git rebase, git reset --hard después de push)**

---

## Resolución de Problemas

### Problema: "Updates were rejected"

```bash
# Alguien hizo push antes que tú
# Solución:
git pull origin main
# Resolver conflictos si hay
git push origin main
```

### Problema: "Your local changes would be overwritten"

```bash
# Tienes cambios sin guardar
# Solución 1: Guardar los cambios
git add .
git commit -m "Guardar cambios antes de pull"
git pull origin main

# Solución 2: Descartar los cambios
git checkout .
git pull origin main

# Solución 3: Guardar temporalmente
git stash
git pull origin main
git stash pop
```

### Problema: Unity muestra errores después de pull

```bash
# 1. Cerrar Unity completamente
# 2. Hacer git pull
# 3. Eliminar carpetas temporales:
rm -rf Library/
rm -rf Temp/
# 4. Abrir Unity de nuevo (regenerará las carpetas)
```

### Problema: Archivos LFS no se descargan

```bash
# Verificar instalación de LFS
git lfs version

# Re-instalar LFS en el repo
git lfs install

# Forzar descarga de archivos LFS
git lfs pull

# Ver archivos LFS
git lfs ls-files
```

### Problema: Repositorio muy pesado

```bash
# Limpiar archivos LFS antiguos
git lfs prune

# Ver tamaño del repo
git count-objects -vH
```

### Problema: Olvidé hacer pull antes de trabajar

```bash
# Si NO has hecho commit:
git stash
git pull origin main
git stash pop

# Si YA hiciste commit:
git pull origin main
# Resolver conflictos si hay
git push origin main
```

---

## Git LFS - Archivos Grandes

### ¿Qué es Git LFS?

Git LFS (Large File Storage) es una extensión que maneja archivos grandes de forma eficiente. En lugar de guardar los archivos completos en cada versión, guarda un puntero y mantiene los archivos grandes en un servidor separado.

### Archivos que Usan LFS en Este Proyecto

Según el `.gitattributes`, estos formatos usan LFS:

**Imágenes:**
- .png, .jpg, .jpeg, .psd, .tga, .bmp, .svg

**Audio:**
- .mp3, .wav, .ogg

**Video:**
- .mp4, .mov, .avi

**3D:**
- .fbx, .obj, .blend

**Unity:**
- .unity, .prefab, .asset, .psb

### Comandos LFS Útiles

```bash
# Ver archivos trackeados por LFS
git lfs ls-files

# Ver tamaño de archivos LFS
git lfs ls-files -s

# Descargar todos los archivos LFS
git lfs pull

# Ver qué archivos están configurados para LFS
git lfs track

# Limpiar archivos LFS antiguos (liberar espacio)
git lfs prune

# Ver estado de LFS
git lfs status
```

### Agregar Nuevos Tipos de Archivo a LFS

Si necesitas agregar un nuevo tipo de archivo grande:

```bash
# Agregar tipo de archivo
git lfs track "*.nuevaextension"

# Esto modifica .gitattributes
git add .gitattributes
git commit -m "Config: Agregar .nuevaextension a LFS"
git push origin main
```

---

## Flujo de Trabajo Recomendado para Equipo

### Opción 1: Feature Branch (Recomendado)

```bash
# Developer 1: Trabajando en nuevo enemigo
git checkout -b feature/nuevo-enemigo
# ... hacer cambios ...
git add .
git commit -m "Feature: Agregar enemigo araña"
git push origin feature/nuevo-enemigo
# Crear Pull Request en GitHub/GitLab

# Developer 2: Trabajando en UI
git checkout -b feature/mejorar-hud
# ... hacer cambios ...
git add .
git commit -m "Feature: Rediseñar HUD de vida"
git push origin feature/mejorar-hud
# Crear Pull Request

# Líder de equipo: Revisar y fusionar en GitHub/GitLab
# Luego todos actualizan:
git checkout main
git pull origin main
```

### Opción 2: Trabajo Directo en Main (Solo para equipos pequeños)

```bash
# ANTES de empezar
git pull origin main

# Trabajar
git add .
git commit -m "Update: Ajustar velocidad del player"

# Subir inmediatamente
git push origin main

# Comunicar al equipo en chat: "Push realizado, hagan pull"
```

---

## Comandos Rápidos de Referencia

```bash
# === INICIO DEL DÍA ===
git pull origin main
git lfs pull

# === DURANTE EL TRABAJO ===
git status                              # Ver cambios
git diff                                # Ver diferencias

# === GUARDAR CAMBIOS ===
git add .                               # Agregar todo
git add Assets/Scripts/MiScript.cs      # Agregar archivo específico
git commit -m "Mensaje descriptivo"     # Guardar commit
git push origin main                    # Subir al servidor

# === VER HISTORIAL ===
git log --oneline                       # Ver commits
git log --graph --all                   # Ver ramas

# === RAMAS ===
git branch                              # Ver ramas
git checkout -b feature/nombre          # Crear y cambiar a rama
git checkout main                       # Volver a main
git merge feature/nombre                # Fusionar rama

# === EMERGENCIAS ===
git stash                               # Guardar temporal
git checkout .                          # Descartar cambios
git reset --hard HEAD~1                 # Deshacer último commit

# === GIT LFS ===
git lfs ls-files                        # Ver archivos LFS
git lfs pull                            # Descargar archivos LFS
git lfs prune                           # Limpiar LFS
```

---

## Configuración de GitHub/GitLab

### Crear Repositorio en GitHub

1. Ir a https://github.com
2. Click en "New repository"
3. Nombre: `nabhi-legado-ed`
4. Descripción: "Videojuego 2D de plataformas - NABHI: El Legado de ED"
5. **No marcar** "Initialize with README"
6. **No agregar** .gitignore (ya lo tenemos)
7. Click "Create repository"

### Conectar Repositorio Local

```bash
git remote add origin https://github.com/tu-usuario/nabhi-legado-ed.git
git branch -M main
git push -u origin main
```

### Configurar LFS en GitHub

GitHub soporta Git LFS de forma nativa, pero tiene límites:
- **Gratuito:** 1 GB de almacenamiento LFS, 1 GB de ancho de banda/mes
- **Pro:** 50 GB de almacenamiento, 50 GB de ancho de banda/mes

**Alternativa:** GitLab ofrece más espacio LFS gratis (10 GB).

---

## Primer Commit del Proyecto

```bash
# Ya se ejecutó git init
# Ya se ejecutó git lfs install
# Ya existen .gitignore y .gitattributes

# Agregar todos los archivos
git add .

# Ver qué se va a guardar
git status

# Crear el primer commit
git commit -m "Initial commit: Proyecto NABHI - El Legado de ED con Unity 2021.3.13f1"

# Conectar con repositorio remoto (crea el repo en GitHub primero)
git remote add origin https://github.com/tu-usuario/nabhi-legado-ed.git

# Subir el primer commit
git push -u origin main
```

**Nota:** El primer push puede tardar mucho debido a los archivos LFS (imágenes, audio, etc.). Esto es normal.

---

## Consejos Finales

1. **Comunicación:** Avisar al equipo cuando hagas push de cambios grandes
2. **Pull frecuente:** Hacer `git pull` varias veces al día
3. **Commits atómicos:** Cada commit debe ser una unidad lógica de cambio
4. **Probar antes de push:** Siempre probar el juego en Unity antes de subir
5. **Documentar:** Actualizar este documento con problemas que encuentres
6. **Backup:** Tener backup manual de PlayerPrefs y configuraciones personales

---

## Recursos Adicionales

- **Git Documentation:** https://git-scm.com/doc
- **Git LFS:** https://git-lfs.github.com/
- **GitHub Guides:** https://guides.github.com/
- **Atlassian Git Tutorial:** https://www.atlassian.com/git/tutorials
- **Unity Version Control Guide:** https://unity.com/how-to/version-control-systems

---

**Última actualización:** 2025-09-30
**Versión del documento:** 1.0
**Mantenedor:** Equipo Aristas Studios
