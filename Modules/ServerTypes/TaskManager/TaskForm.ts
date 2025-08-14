import { StringEditor, DateEditor, EnumEditor, BooleanEditor, PrefixedContext, initFormType } from "@serenity-is/corelib";
import { TaskPriority } from "./TaskPriority";

export interface TaskForm {
    Title: StringEditor;
    Description: StringEditor;
    DueDate: DateEditor;
    Priority: EnumEditor;
    IsCompleted: BooleanEditor;
    InsertDate: DateEditor;
}

export class TaskForm extends PrefixedContext {
    static readonly formKey = 'TaskManager.Task';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!TaskForm.init)  {
            TaskForm.init = true;

            var w0 = StringEditor;
            var w1 = DateEditor;
            var w2 = EnumEditor;
            var w3 = BooleanEditor;

            initFormType(TaskForm, [
                'Title', w0,
                'Description', w0,
                'DueDate', w1,
                'Priority', w2,
                'IsCompleted', w3,
                'InsertDate', w1
            ]);
        }
    }
}

[TaskPriority]; // referenced types