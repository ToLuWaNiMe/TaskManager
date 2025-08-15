import { Decorators, EntityDialog, serviceRequest } from '@serenity-is/corelib';
import { TaskReportForm } from "../../ServerTypes/Modules/TaskManager.Task.TaskReportForm";
import { TaskSummaryRequest } from '../../ServerTypes/Modules/TaskManager.Task.TaskSummaryRequest';

@Decorators.registerClass('TaskManager.TaskManager.TaskReportDialog')
export class TaskReportDialog extends EntityDialog<TaskSummaryRequest, any> {
    protected getFormKey() {
        return TaskReportForm.formKey;
    }
    protected form = new TaskReportForm(this.idPrefix);

    protected onDialogOpen() {
        super.onDialogOpen();
        // unwrap Fluent → jQuery → DOM element
        const dialogEl = (this.element as any).closest('.ui-dialog')[0] as HTMLElement;
        if (!dialogEl) {
            console.warn('TaskReportDialog: Could not find .ui-dialog container.');
            return;
        }

        const buttonPane = dialogEl.querySelector('.ui-dialog-buttonpane');
        if (!buttonPane) {
            console.warn('TaskReportDialog: Could not find .ui-dialog-buttonpane.');
            return;
        }

        const btn = document.createElement('button');
        btn.textContent = 'Generate';
        btn.type = 'button';
        btn.className = 'btn btn-primary generate-report';

        buttonPane.appendChild(btn);

        btn.addEventListener('click', () => {
            const request: TaskSummaryRequest = {
                StartDate: this.form.StartDate.value,
                EndDate: this.form.EndDate.value
            };

            serviceRequest('TaskManager/Task/Generate', request, response => {
                console.log('Report Result:', response);
                alert(JSON.stringify(response, null, 2));
            });
        });
    }
}