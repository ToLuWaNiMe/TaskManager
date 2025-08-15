import { Decorators, EntityGrid, formatDate, EnumEditor, BooleanEditor, QuickFilter, Widget } from '@serenity-is/corelib';
import { TaskColumns, TaskPriority, TaskRow, TaskService } from '../../ServerTypes/TaskManager';
import { TaskDialog } from './TaskDialog';
import { TaskReportDialog } from './TaskReportDialog';

@Decorators.registerClass('TaskManager.TaskManager.TaskGrid')
export class TaskGrid extends EntityGrid<TaskRow, any> {
    protected getColumnsKey() { return TaskColumns.columnsKey; }
    protected getDialogType() { return TaskDialog; }
    protected getRowDefinition() { return TaskRow; }
    protected getService() { return TaskService.baseUrl; }

    //Method to customize columns
    protected getColumns() {
        const columns = super.getColumns();

        return [
            {
                field: "Title",
                name: "Title",
                width: 200
            },
            {
                field: "Description",
                name: "Description",
                width: 300
            },
            {
                field: "DueDate",
                name: "Due Date",
                width: 120,
                format: ctx => formatDate(ctx.value)
            },
            {
                field: "Priority",
                name: "Priority",
                width: 100,
                formatter: ctx => TaskPriority[ctx.value] || ""
            },
            {
                field: "IsCompleted",
                name: "Completed",
                width: 80,
                formatter: ctx => ctx.value ? "✓" : ""
            },
            {
                field: "InsertDate",
                name: "Insert Date",
                width: 120,
                formatter: ctx => formatDate(ctx.value) 
            }
        ];
    }

    protected getQuickFilters(): QuickFilter<Widget<any>, any>[] {
        return [
            {
                type: EnumEditor,
                options: { enumKey: "TaskManager.TaskManager.TaskPriority" },
                field: "Priority",
                title: "Priority"
            },

            {
                type: BooleanEditor,
                field: "IsCompleted",
                title: "Completed"
            }
        ];
    }

    protected getButtons() {
        const buttons = super.getButtons();
        buttons.push({
            title: "Generate Report",
            cssClass: "export-pdf-button",
            onClick: () => {
                new TaskReportDialog().dialogOpen();
            }
        });
        return buttons;
    }
}