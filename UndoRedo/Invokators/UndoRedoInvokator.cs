using UndoRedo.Contracts;

namespace UndoRedo.Invokators;

public class UndoRedoInvokator : IUndoRedoInvokator
{
    private Stack<IUndoRedoCommand> _undoCommands = new Stack<IUndoRedoCommand>();
    private Stack<IUndoRedoCommand> _redoCommands = new Stack<IUndoRedoCommand>();


    public void AddCommand(IUndoRedoCommand command)
    {
        _undoCommands.Push(command);
    }

    public void AddCommands(IEnumerable<IUndoRedoCommand> commands)
    {
        foreach(var command in commands){
                AddCommand(command);
        }
    }

    public void ExecuteRedoCommand()
    {
        _redoCommands.Peek().Redo();
        _undoCommands.Push(_redoCommands.Pop());
    }

    public void ExecuteUndoCommand()
    {
        _undoCommands.Peek().Undo();
        _redoCommands.Push(_undoCommands.Pop());
    }

    public IEnumerable<IUndoRedoCommand> GetRedoCommandStack()
    {
        return _redoCommands;
    }

    public IEnumerable<IUndoRedoCommand> GetUndoCommandStack()
    {
        return _undoCommands;
    }
}

