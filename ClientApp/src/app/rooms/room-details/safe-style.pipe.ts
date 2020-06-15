import {Pipe} from "@angular/core";
import {DomSanitizer} from "@angular/platform-browser";

@Pipe({
    name: 'safeStyle'
})
export class SafeStylePipe {
    constructor(private sanitizer: DomSanitizer) {
    }

    transform(val: string) {
        return this.sanitizer.bypassSecurityTrustStyle(`url('${val}')`);
    }
}
