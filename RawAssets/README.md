# RawAssets/

Unity에 임포트하기 전 **원본 작업 파일** 보관 폴더입니다.
Git LFS로 관리됩니다.

## 구조

| 폴더 | 내용 |
|------|------|
| `2D/Characters/` | NPC 초상화 원본 (.psd, .ai) |
| `2D/Backgrounds/` | 배경 일러스트 원본 |
| `2D/Cutscene/` | 업경 컷신 장면 원본 |
| `2D/UI/` | UI 디자인 원본 |
| `2D/Concept/` | 컨셉아트, 레퍼런스 |
| `Audio/BGM/` | BGM 원본 (.wav, DAW 프로젝트) |
| `Audio/SFX/` | 효과음 원본 |

## 파일 명명 규칙

```
에셋유형_이름_버전.확장자

예시:
  CH_Victim01_v02.psd          ← NPC 초상화
  BG_JudgementRoom_v01.psd     ← 배경
  CS_Mirror_Scene03_v01.psd    ← 업경 컷신 장면
  AU_BGM_Main_v01.wav          ← BGM
  AU_SFX_MirrorActivate.wav    ← 효과음
```

## 규칙

- 작업이 완료된 파일만 이곳으로 옮깁니다
- 작업 중인 파일은 `_WIP/본인폴더/` 에 보관합니다
