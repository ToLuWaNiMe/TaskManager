import { DateEditor, PrefixedContext, initFormType } from "@serenity-is/corelib";

export interface TaskReportForm {
    StartDate: DateEditor;
    EndDate: DateEditor;
}

export class TaskReportForm extends PrefixedContext {
    static readonly formKey = 'TaskManager.TaskReport';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!TaskReportForm.init)  {
            TaskReportForm.init = true;

            var w0 = DateEditor;

            initFormType(TaskReportForm, [
                'StartDate', w0,
                'EndDate', w0
            ]);
        }
    }
}