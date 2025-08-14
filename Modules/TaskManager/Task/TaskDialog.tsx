import { Decorators, EntityDialog } from '@serenity-is/corelib';
import { TaskForm, TaskRow, TaskService } from '../../ServerTypes/TaskManager';

@Decorators.registerClass('TaskManager.TaskManager.TaskDialog')
export class TaskDialog extends EntityDialog<TaskRow, any> {
    protected getFormKey() { return TaskForm.formKey; }
    protected getRowDefinition() { return TaskRow; }
    protected getService() { return TaskService.baseUrl; }

    protected form = new TaskForm(this.idPrefix);
}