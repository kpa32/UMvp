# UMvp - Unity3D MVP Framework

UMvp 是一个基于 Unity3D 的 C# MVP (Model-View-Presenter) 架构框架，用于帮助开发者构建可维护、可扩展的 Unity 游戏项目。

## 项目结构

```
CodeFramework/
├── Assets/
│   ├── UMvp/              # 核心框架代码
│   │   └── Core/
│   │       ├── Component/ # 组件模块
│   │       ├── Config/    # 配置模块
│   │       ├── Const/     # 常量定义
│   │       ├── Game/      # 游戏逻辑
│   │       ├── JsonForUnity/ # JSON 序列化支持
│   │       ├── Manager/   # 管理器模块
│   │       ├── Mvp/       # MVP 架构核心
│   │       ├── Net/       # 网络模块
│   │       └── Scene/     # 场景管理
│   ├── NGUI/              # NGUI 界面系统
│   └── Game/              # 游戏具体内容
│       ├── Scenes/        # 场景文件
│       └── Scripts/       # 游戏脚本
└── ProjectSettings/       # Unity 项目设置
```

## 主要特性

- **MVP 架构**: 清晰的模型 - 视图 - 呈现器分离，提高代码可维护性
- **模块化设计**: 包含组件、配置、管理器等独立模块
- **网络支持**: 内置网络通信模块
- **JSON 序列化**: 集成 JsonForUnity 支持数据序列化
- **场景管理**: 提供场景切换和管理功能
- **NGUI 集成**: 支持 NGUI 界面系统

## 使用方式

1. 使用 Unity 打开 `CodeFramework` 目录
2. 导入项目到 Unity 编辑器
3. 参考框架结构进行游戏开发

## 技术栈

- Unity3D
- C#
- MVP 设计模式
- NGUI

## 联系方式

- Email: 473926009@qq.com

## 许可证

请查看项目中的相关许可协议文件。
