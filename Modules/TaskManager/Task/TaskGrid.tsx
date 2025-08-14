import { Decorators, EntityGrid } from '@serenity-is/corelib';
import { TaskColumns, TaskRow, TaskService } from '../../ServerTypes/TaskManager';
import { TaskDialog } from './TaskDialog';

@Decorators.registerClass('TaskManager.TaskManager.TaskGrid')
export class TaskGrid extends EntityGrid<TaskRow> {
    protected getColumnsKey() { return TaskColumns.columnsKey; }
    protected getDialogType() { return TaskDialog; }
    protected getRowDefinition() { return TaskRow; }
    protected getService() { return TaskService.baseUrl; }
}