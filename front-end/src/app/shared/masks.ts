import { AbstractControl } from "@angular/forms"
import { conformToMask } from "angular2-text-mask"
import { createNumberMask } from "text-mask-addons"

export const cnjMask = [
    /\d/,
    /\d/,
    /\d/,
    /\d/,
    /\d/,
    /\d/,
    /\d/,
    '-',
    /\d/,
    /\d/,
    /\d/,
    /\d/,
    '.',
    /\d/,
    '.',
    /\d/,
    /\d/,
    '.',
    /\d/,
    /\d/,
    /\d/,
    /\d/,
  ]

  export const MaskValidator = mask => (control:AbstractControl) => {
    if(!control.value)
      return null
    const conformed = conformToMask(control.value,mask,{guide:false})
      if(control.value !== '' && conformed.meta.someCharsRejected)
        return {mask:conformToMask('',mask,{guide:true, placeholderChar: 'X'})}
    return null
  }

export interface mask {
    mask?: (string|RegExp)[]
    guide?:boolean
    keepCharPosition?:boolean
    showMask?:boolean
  }
