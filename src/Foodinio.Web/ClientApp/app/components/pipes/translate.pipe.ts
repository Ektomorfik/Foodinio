import { Pipe, PipeTransform } from '@angular/core';
import { Translations } from '../../global/Translations';

@Pipe({
  name: 'translate'
})
export class TranslatePipe implements PipeTransform {

  transform(value: any, args?: any): string {
    const translation = Translations.GetValue(value);
    return translation;
  }

}