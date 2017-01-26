//////////////////////////////////
//Auto-generated. Do NOT modify!//
//////////////////////////////////

import { MessageKey, QueryKey, Type, EnumType, registerSymbol } from '../../../Framework/Signum.React/Scripts/Reflection'
import * as Entities from '../../../Framework/Signum.React/Scripts/Signum.Entities'
import * as Processes from '../Processes/Signum.Entities.Processes'
import * as Files from '../Files/Signum.Entities.Files'
import * as Authorization from '../Authorization/Signum.Entities.Authorization'


export const PrintLineEntity = new Type<PrintLineEntity>("PrintLine");
export interface PrintLineEntity extends Entities.Entity, Processes.IProcessLineDataEntity {
    Type: "PrintLine";
    creationDate?: string;
    file?: Files.EmbeddedFilePathEntity | null;
    package?: Entities.Lite<PrintPackageEntity> | null;
    printedOn?: string | null;
    referred?: Entities.Lite<Entities.Entity> | null;
    state?: PrintLineState;
}

export module PrintLineOperation {
    export const Print : Entities.ExecuteSymbol<PrintLineEntity> = registerSymbol("Operation", "PrintLineOperation.Print");
    export const Retry : Entities.ExecuteSymbol<PrintLineEntity> = registerSymbol("Operation", "PrintLineOperation.Retry");
    export const Cancel : Entities.ExecuteSymbol<PrintLineEntity> = registerSymbol("Operation", "PrintLineOperation.Cancel");
}

export const PrintLineState = new EnumType<PrintLineState>("PrintLineState");
export type PrintLineState =
    "ReadyToPrint" |
    "Enqueued" |
    "Printed" |
    "Cancelled" |
    "Error";

export const PrintPackageEntity = new Type<PrintPackageEntity>("PrintPackage");
export interface PrintPackageEntity extends Entities.Entity, Processes.IProcessDataEntity {
    Type: "PrintPackage";
    name?: string | null;
}

export module PrintPackageProcess {
    export const PrintPackage : Processes.ProcessAlgorithmSymbol = registerSymbol("ProcessAlgorithm", "PrintPackageProcess.PrintPackage");
}

export module PrintPermission {
    export const ViewPrintPanel : Authorization.PermissionSymbol = registerSymbol("Permission", "PrintPermission.ViewPrintPanel");
}


