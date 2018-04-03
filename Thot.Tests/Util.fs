module Util.Testing

open Expecto

let testList name tests = testList name tests
let ptestList name tests = ptestList name tests
let testCase msg test = testCase msg test
let ptestCase msg test = ptestCase msg test

let equal expected actual: unit =
    Expect.equal actual expected ""

type Test = Expecto.Test

