module Thot.Bson.Net.Encode

open MongoDB.Bson
open System.IO

type Replacer = string -> obj -> obj

///**Description**
/// Encode a string
///
///**Parameters**
///  * `value` - parameter of type `string`
///
///**Output Type**
///  * `Value`
///
///**Exceptions**
///
let string (value : string) : BsonValue =
    BsonString value :> BsonValue

///**Description**
/// Encode an int
///
///**Parameters**
///  * `value` - parameter of type `int`
///
///**Output Type**
///  * `Value`
///
///**Exceptions**
///
let int (value : int) : BsonValue =
    BsonInt32 value :> BsonValue

///**Description**
/// Encode a Float. `Infinity` and `NaN` are encoded as `null`.
///
///**Parameters**
///  * `value` - parameter of type `float`
///
///**Output Type**
///  * `Value`
///
///**Exceptions**
///
let float (value : float) : BsonValue =
    BsonDouble value :> BsonValue

///**Description**
/// Encode null
///
///**Parameters**
///
///**Output Type**
///  * `Value`
///
///**Exceptions**
///
let nil : BsonValue =
    BsonNull.Value :> BsonValue

///**Description**
/// Encode a bool
///**Parameters**
///  * `value` - parameter of type `bool`
///
///**Output Type**
///  * `Value`
///
///**Exceptions**
///
let bool (value : bool) : BsonValue =
    BsonBoolean value :> BsonValue

///**Description**
/// Encode an object
///
///**Parameters**
///  * `values` - parameter of type `(string * Value) list`
///
///**Output Type**
///  * `Value`
///
///**Exceptions**
///
let object (values : (string * BsonValue) list) : BsonValue =
    values
    |> List.map (fun (key, value) ->
        BsonElement(key, value)
    )
    |> BsonDocument :> BsonValue

///**Description**
/// Encode an array
///
///**Parameters**
///  * `values` - parameter of type `Value array`
///
///**Output Type**
///  * `Value`
///
///**Exceptions**
///
let array (values : array<BsonValue>) : BsonValue =
    BsonArray values :> BsonValue

///**Description**
/// Encode a list
///**Parameters**
///  * `values` - parameter of type `Value list`
///
///**Output Type**
///  * `Value`
///
///**Exceptions**
///
let list (values : BsonValue list) : BsonValue =
    BsonArray values :> BsonValue

///**Description**
/// Encode a dictionary
///**Parameters**
///  * `values` - parameter of type `Map<string, Value>`
///
///**Output Type**
///  * `Value`
///
///**Exceptions**
///
let dict (values : Map<string, BsonValue>) =
    values
    |> Map.toList
    |> object

///**Description**
/// Convert a `Value` into a prettified string.
///**Parameters**
///  * `value` - parameter of type `obj` - Value to convert
///
///**Output Type**
///  * `string`
///
///**Exceptions**
///
let encode (token: BsonValue) : string =
    token.ToJson()

///**Description**
/// Convert a `Value` into bytes.
///**Parameters**
///  * `value` - parameter of type `obj` - Value to convert
///
///**Output Type**
///  * `bytes[]`
///
///**Exceptions**
///
let encodeBytes (token: BsonValue) : byte[] =
    token.ToBson()

///**Description**
/// Encode an option
///**Parameters**
///  * `encoder` - parameter of type `'a -> Value`
///
///**Output Type**
///  * `'a option -> Value`
///
///**Exceptions**
///
let option (encoder : 'a -> BsonValue) =
    Option.map encoder >> Option.defaultWith (fun _ -> nil)
