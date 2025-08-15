import { ServiceOptions, SaveRequest, SaveResponse, DeleteRequest, DeleteResponse, RetrieveRequest, RetrieveResponse, ListRequest, ListResponse, serviceRequest } from "@serenity-is/corelib";
import { TaskSummaryRequest } from "../Modules/TaskManager.Task.TaskSummaryRequest";
import { TaskSummaryResult } from "../Modules/TaskManager.Task.TaskSummaryResult";
import { TaskRow } from "./TaskRow";

export namespace TaskService {
    export const baseUrl = 'TaskManager/Task';

    export declare function Generate(request: TaskSummaryRequest, onSuccess?: (response: TaskSummaryResult[]) => void, opt?: ServiceOptions<any>): PromiseLike<TaskSummaryResult[]>;
    export declare function Create(request: SaveRequest<TaskRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Update(request: SaveRequest<TaskRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Delete(request: DeleteRequest, onSuccess?: (response: DeleteResponse) => void, opt?: ServiceOptions<any>): PromiseLike<DeleteResponse>;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<TaskRow>) => void, opt?: ServiceOptions<any>): PromiseLike<RetrieveResponse<TaskRow>>;
    export declare function List(request: ListRequest, onSuccess?: (response: ListResponse<TaskRow>) => void, opt?: ServiceOptions<any>): PromiseLike<ListResponse<TaskRow>>;

    export const Methods = {
        Generate: "TaskManager/Task/Generate",
        Create: "TaskManager/Task/Create",
        Update: "TaskManager/Task/Update",
        Delete: "TaskManager/Task/Delete",
        Retrieve: "TaskManager/Task/Retrieve",
        List: "TaskManager/Task/List"
    } as const;

    [
        'Generate', 
        'Create', 
        'Update', 
        'Delete', 
        'Retrieve', 
        'List'
    ].forEach(x => {
        (<any>TaskService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}