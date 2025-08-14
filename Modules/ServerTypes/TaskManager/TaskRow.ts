import { fieldsProxy } from "@serenity-is/corelib";
import { TaskPriority } from "./TaskPriority";

export interface TaskRow {
    TaskId?: number;
    Title?: string;
    Description?: string;
    DueDate?: string;
    Priority?: TaskPriority;
    IsCompleted?: boolean;
    InsertDate?: string;
}

export abstract class TaskRow {
    static readonly idProperty = 'TaskId';
    static readonly nameProperty = 'Title';
    static readonly localTextPrefix = 'TaskManager.Task';
    static readonly deletePermission = 'Administration:General';
    static readonly insertPermission = 'Administration:General';
    static readonly readPermission = 'Administration:General';
    static readonly updatePermission = 'Administration:General';

    static readonly Fields = fieldsProxy<TaskRow>();
}