# Unity Endless Runner (MVP)

Este repositorio contiene el esqueleto inicial para un juego 3D estilo "endless runner" (tipo Subway Surfers) creado para Unity 2022.3 LTS.

Contenido
- Assets/Scripts/: scripts C# principales (PlayerController, ObstacleSpawner, GameManager)
- Packages/manifest.json: configuración mínima de paquetes Unity
- ProjectSettings/ProjectVersion.txt: versión de Unity objetivo
- .gitignore y .gitattributes: configuraciones para Unity y Git LFS

Notas importantes
- Este commit incluye solo el esqueleto de proyecto con scripts y archivos de configuración. Los assets gráficos HD (modelos, texturas, audio) no se incluyen por tamaño y licencia. Utiliza Asset Store o agrega tus propios assets en Assets/.
- iOS: el proyecto está configurado para iOS export (Player Settings), pero no se incluye un .ipa final. Para compilar a iOS abre el proyecto en Unity en macOS y genera el Xcode project desde Build Settings.

Cómo abrir
1. Instala Unity 2022.3 LTS (recomendado).
2. Clona el repo: git clone https://github.com/BtaStore0/Game2.0.git
3. Abre la carpeta en Unity Hub y selecciona la versión 2022.3.x
4. Abre o crea la escena Main (Assets/Scenes/)

Builds (local)
- Windows: Build Settings → PC, Mac & Linux Standalone → Build
- Android: instala Android Build Support y SDK desde Unity Hub, luego Build Settings → Android → Build
- iOS: Build Settings → iOS → Build (genera Xcode project) → abrir con Xcode y compilar en macOS

Próximos pasos que puedo completar si quieres
- Añadir assets HD gratuitos y configurar materiales / post-processing
- Crear escena Main completa con prefabs y un sistema de spawner más avanzado
- Generar builds Windows (.exe) y Android (.apk) y crear Release con ZIP

Si quieres que suba builds y assets, confirma y los prepararé y crearé una Release con el ZIP listo para descargar.confirma
