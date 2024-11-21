using UndoRedo.Contracts;

namespace UndoRedo.Commands;

public class UndoRedoCommand<T> : IUndoRedoCommand where T : IUndoRedoSnapshot
{
    private readonly T _undoSnapshot;
    private readonly T _redoSnapshot;
    private readonly IUndoRedoRecoverService<T> _recoverService;

    public UndoRedoCommand(T undoSnapshot , T redoSnapshot , IUndoRedoRecoverService<T> recoverService)
    {
        _undoSnapshot = undoSnapshot;
        _redoSnapshot = redoSnapshot;
        _recoverService = recoverService;
    }
    public void Redo()
    {
        _recoverService.Recover(_redoSnapshot);
    }

    public void Undo()
    {
        _recoverService.Recover(_undoSnapshot);
    }
}
