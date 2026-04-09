# Project/

Unity 2D 프로젝트 본체 폴더입니다.

## 구조

| 폴더 | 내용 |
|------|------|
| `Assets/_Game/Sprites/` | 임포트된 스프라이트 이미지 |
| `Assets/_Game/Sprites/Characters/` | NPC 초상화 |
| `Assets/_Game/Sprites/Backgrounds/` | 배경 일러스트 |
| `Assets/_Game/Sprites/Cutscene/` | 업경 컷신 장면 일러스트 |
| `Assets/_Game/Sprites/UI/` | UI 이미지 |
| `Assets/_Game/Audio/BGM/` | 배경음악 |
| `Assets/_Game/Audio/SFX/` | 효과음 |
| `Assets/_Game/UI/` | UI 프리팹 |
| `Assets/_Game/Scenes/` | Unity 씬 파일 |
| `Assets/_Game/Scripts/` | C# 스크립트 |
| `Assets/_Game/Data/` | NPC·대화·플래그 데이터 (JSON) |
| `Assets/_Dev/` | 테스트·개발용 (빌드 제외) |

## 규칙

- `Assets/_Game/` 에는 **검수 완료된 에셋만** 넣습니다
- 원본 파일(.psd, .wav 등)은 `RawAssets/` 에 보관합니다
- Sprites·Audio 파일은 Git LFS로 자동 관리됩니다
- Scripts·Data(.cs, .json)는 일반 Git으로 관리됩니다

## Data 폴더 구조

```
Data/
├── NPC/          NPC 프로필 JSON (npc_01.json, npc_02.json ...)
├── Dialogue/     대화 분기 데이터 JSON
└── Flags/        정보 플래그 정의 JSON
```
