import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { TaskPriority } from "./TaskPriority";
import { TaskRow } from "./TaskRow";

export interface TaskColumns {
    TaskId: Column<TaskRow>;
    Title: Column<TaskRow>;
    Description: Column<TaskRow>;
    DueDate: Column<TaskRow>;
    Priority: Column<TaskRow>;
    IsCompleted: Column<TaskRow>;
    InsertDate: Column<TaskRow>;
}

export class TaskColumns extends ColumnsBase<TaskRow> {
    static readonly columnsKey = 'TaskManager.Task';
    static readonly Fields = fieldsProxy<TaskColumns>();
}

[TaskPriority]; // referenced types