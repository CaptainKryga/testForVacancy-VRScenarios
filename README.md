# 🚀 VR Training Simulator 🎮  
**A modular training system with step-by-step scenarios in Unity**  

---

## 🌍 Project Overview  
This VR project is a training simulator with interactive step-by-step scenarios, built using **Unity** and **XR Interaction Toolkit**. The architecture follows an **event-driven** system while adhering to **SOLID principles**.  

### 🔑 Key Features  
- 🎯 **Centralized Controllers**  
  - `ScenarioController` & `ScenarioTaskController` for step logic  
  - `SyncManager` for scene object synchronization  
  - `ScenarioManager` for task/event validation  
- 🕹️ **Dual Input Support**  
  - VR controllers (Meta Quest, etc.)  
  - Mouse & Keyboard (non-VR debug mode)  
- 📜 **Scriptable Scenarios**  
  - Flexible scenario creation via ScriptableObjects  
  - Action-based validation using link Action 

### ⚠️ Known Issues  
1. **`SRP Violation`** 🛑  
   - `ScenarioTaskController` became too complex (breaks Single Responsibility Principle)  
2. **Error-Prone Scenario Setup** ❗  
   - No validation for:  
     - Empty fields in scenario steps  
     - Missing components in step/groups  

### 🐞 UI Bug  
- **"Scenario 0" start button** only responds to:  
  - Left VR controller raycast (Canvas)  
  - Mouse click (non-VR mode)  

---

## 🌍 Описание проекта  
Этот VR-тренажёр предназначен для пошагового обучения, созданный на **Unity** с **XR Interaction Toolkit**. Архитектура использует **событийную систему** и принципы **SOLID**.  

### 🔑 Основные возможности  
- 🎯 **Централизованные контроллеры**  
  - `ScenarioController` и `ScenarioTaskController` — управление шагами  
  - `SyncManager` — синхронизация объектов  
  - `ScenarioManager` — проверка выполнения задач  
- 🕹️ **Двойной ввод**  
  - VR-контроллеры (Meta Quest и др.)  
  - Клавиатура/мышь (режим отладки)  
- 📜 **Гибкие сценарии**  
  - Настройка через ScriptableObjects  
  - Проверка через линк Action  

### ⚠️ Известные проблемы  
1. **Нарушение SRP** 🛑  
   - `ScenarioTaskController` стал слишком сложным (принцип единственной ответственности)  
2. **Нет защиты от ошибок** ❗  
   - Нет проверки на:  
     - Пустые поля в сценарии  
     - Отсутствующие компоненты в шагах/группах  

### 🐞 Ошибка UI  
- Кнопка **"Сценарий 0"** реагирует только на:  
  - Левый VR-контроллер (канвас)  
  - Клик мыши (вне VR)  

---
