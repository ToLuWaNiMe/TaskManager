import { ServiceRequest } from "@serenity-is/corelib";

export interface TaskSummaryRequest extends ServiceRequest {
    StartDate?: string;
    EndDate?: string;
}