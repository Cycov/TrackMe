"use strict";
var __importStar = (this && this.__importStar) || function (mod) {
    if (mod && mod.__esModule) return mod;
    var result = {};
    if (mod != null) for (var k in mod) if (Object.hasOwnProperty.call(mod, k)) result[k] = mod[k];
    result["default"] = mod;
    return result;
};
Object.defineProperty(exports, "__esModule", { value: true });
var util_1 = require("util");
var request = __importStar(require("request"));
var _headers = {
    'User-Agent': 'Mozilla/5.0 (Macintosh; Intel Mac OS X 10.8; rv:24.0) Gecko/20100101 Firefox/24.0',
    'Content-Type': 'application/x-www-form-urlencoded'
};
var NotifyMeCallbackEventArgs = (function () {
    function NotifyMeCallbackEventArgs(title, text) {
        this.title = title;
        this.text = text;
    }
    NotifyMeCallbackEventArgs.prototype.getJSON = function () {
        return JSON.stringify(this);
    };
    return NotifyMeCallbackEventArgs;
}());
exports.NotifyMeCallbackEventArgs = NotifyMeCallbackEventArgs;
var NotifyMeCallback = (function () {
    function NotifyMeCallback(port, ip) {
        if (util_1.isUndefined(ip))
            this.uri = "http://localhost:" + port.toString() + "/eventHandlers/";
        else
            this.uri = "http://" + ip + ":" + port.toString() + "/eventHandlers/";
    }
    NotifyMeCallback.prototype.invoke = function (eventArgs) {
        var options = {
            uri: this.uri,
            form: eventArgs,
            headers: _headers
        };
        request.post(options, function (err, res, body) {
            if (!err)
                console.log(body);
        });
    };
    return NotifyMeCallback;
}());
exports.NotifyMeCallback = NotifyMeCallback;
var HubCallbackEventArgs = (function () {
    function HubCallbackEventArgs(event, data) {
        this.source = "SV_VOICECOMMANDS";
        this.event = event;
        if (util_1.isUndefined(data)) {
            this.data = "{}";
        }
        else {
            if (typeof (data) != "string")
                this.data = JSON.stringify(data);
            else
                this.data = data;
        }
    }
    return HubCallbackEventArgs;
}());
exports.HubCallbackEventArgs = HubCallbackEventArgs;
var HubCallback = (function () {
    function HubCallback(port, ip) {
        if (util_1.isUndefined(ip))
            this.uri = "http://localhost:" + port.toString() + "/eventHandlers/";
        else
            this.uri = "http://" + ip + ":" + port.toString() + "/eventHandlers/";
    }
    HubCallback.prototype.invoke = function (eventArgs) {
        var options = {
            uri: this.uri,
            form: eventArgs,
            headers: _headers
        };
        request.post(options, function (err, res, body) {
            if (!err)
                console.log(body);
        });
    };
    return HubCallback;
}());
exports.HubCallback = HubCallback;
var HubAPIEvents;
(function (HubAPIEvents) {
    HubAPIEvents["START_TRAINING"] = "START_TRAINING";
    HubAPIEvents["STOP_TRAINING"] = "STOP_TRAINING";
    HubAPIEvents["FIRST_APPLICATION"] = "FIRST_APPLICATION";
    HubAPIEvents["STOP_APPLICATION"] = "CLOSE_APPLICATION";
})(HubAPIEvents = exports.HubAPIEvents || (exports.HubAPIEvents = {}));
