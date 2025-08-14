import { Decorators } from "@serenity-is/corelib";

export enum TaskPriority {
    Low = 1,
    Medium = 2,
    High = 3
}
Decorators.registerEnumType(TaskPriority, 'TaskManager.TaskManager.TaskPriority');