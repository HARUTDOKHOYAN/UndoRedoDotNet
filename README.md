# Implementing Undo/Redo Functionality in .NET

This guide explains how to use Undo/Redo functionality using snapshots, a recovery service, and commands.<br>
Follow these steps to integrate it into your application:

---

### 1. Create a Snapshot for Your Model

First, you need to create snapshots representing the state of your model for both undo and redo operations:

```csharp
    undoSnapshot = new AClassSnapshot() { Value = model.Value };
    model.Value = 34;
    redoSnapshot = new AClassSnapshot() { Value = model.Value };
```

### 2. Create a Recovery Service for the Snapshot
Next, create a recovery service that knows how to restore a snapshot to your model:

```csharp
    recoverService = new AClassRecoverService(model);
```

### 3. Create an Undo/Redo Command
Using the snapshots and recovery service, create a command to handle undo and redo operations:

```csharp
command = new UndoRedoCommand<AClassSnapshot>(undoSnapshot, redoSnapshot, recoverService);
```
### 4. Add the Command to the Undo/Redo Service
Register the command with your undo/redo service for execution:

```csharp
UndoRedoService.Instants.Value.AddCommand(command);
```

### 5. Execute Undo/Redo Commands
Finally, execute the undo and redo commands as needed:

``` csharp

UndoRedoService.Instants.Value.Undo();

UndoRedoService.Instants.Value.Redo();
```

### Below is a visual representation of how the Undo/Redo execution process works:
<img width="1261" alt="Screenshot 2024-11-21 at 18 35 19" src="https://github.com/user-attachments/assets/63430980-5b64-4109-a525-2ed930f761e8">
