using UndoRedo.Contracts;
using UndoRedo.Invokators;

namespace UndoRedo.Services;


public class UndoRedoService : IUndoRedoService
{
    public static readonly Lazy<IUndoRedoService> Instants =
        new Lazy<IUndoRedoService>(() => new UndoRedoService());

    private bool _isSubInvocatorActivate;
    private IUndoRedoInvokator _mainInvokator = new UndoRedoInvokator();
    private IUndoRedoInvokator? _subInvokator;


    private IUndoRedoInvokator GetInvokator()
    {
        return _isSubInvocatorActivate? _subInvokator :_mainInvokator;
    }
    public bool IsUndoStackEmpty => !GetInvokator().GetUndoCommandStack().Any();

    public bool IsRedoStackEmpty => !GetInvokator().GetRedoCommandStack().Any();

    public void AddCommand(IUndoRedoCommand command)
    {
        GetInvokator().AddCommand(command);
    }

    public void Redo()
    {
        if(IsRedoStackEmpty) return;
        GetInvokator().ExecuteRedoCommand();
    }

    public void Undo()
    {
        if(IsUndoStackEmpty) return;
        GetInvokator().ExecuteUndoCommand();
    }

    public void ActivateSubInvokator()
    {
        if(_isSubInvocatorActivate) 
            DiactivateSubInvoketor();
        _subInvokator = new UndoRedoInvokator();
        _isSubInvocatorActivate = true;
    }

    public void DiactivateSubInvoketor()
    {
        if(!_isSubInvocatorActivate)
         return;
        _isSubInvocatorActivate = false;
        _mainInvokator.AddCommands(_subInvokator.GetUndoCommandStack());
        _subInvokator = null;
    }
}
