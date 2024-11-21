using System;

namespace UndoRedo.Contracts;

public interface IUndoRedoService{
    void Undo();
    void Redo();
    void AddCommand(IUndoRedoCommand command);
    void ActivateSubInvokator();
    void DiactivateSubInvoketor();
    bool IsUndoStackEmpty{ get; }
    bool IsRedoStackEmpty{ get; }

}
