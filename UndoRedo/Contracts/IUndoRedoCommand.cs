namespace UndoRedo.Contracts;

public interface IUndoRedoCommand
{
  void Undo();
  void Redo();
} 
