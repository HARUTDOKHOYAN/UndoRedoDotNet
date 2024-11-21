using System;

namespace UndoRedo.Contracts;

public interface IUndoRedoInvokator
{
   void  ExecuteUndoCommand();
   void  ExecuteRedoCommand();
   void  AddCommand(IUndoRedoCommand command);
   void  AddCommands(IEnumerable<IUndoRedoCommand> commands);
   IEnumerable<IUndoRedoCommand>   GetUndoCommandStack();
   IEnumerable<IUndoRedoCommand>   GetRedoCommandStack();
}

