
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

  export const dinheiroMask = () =>{

  }
export interface mask {
    mask?: (string|RegExp)[]
    guide?:boolean
    keepCharPosition?:boolean
    showMask?:boolean
  }
