import { ResponseModel } from "./responseModel";

export interface SingleResponseModel<Z> extends ResponseModel{
    data:Z
}