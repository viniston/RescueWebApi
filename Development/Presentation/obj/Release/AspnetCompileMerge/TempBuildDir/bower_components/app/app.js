/**
 * @file 
 * Provides main Backbone view events and models.
 *
 * all te backbone events and models are presence here
 *
 * Author: Viniston Fernando
 */
$(document).ready(function () {

    $.fn.serializeObject = function () {
        var o = {};
        var a = this.serializeArray();
        $.each(a, function () {
            if (o[this.name] !== undefined) {
                if (!o[this.name].push) {
                    o[this.name] = [o[this.name]];
                }
                o[this.name].push(this.value || '');
            } else {
                o[this.name] = this.value || '';
            }
        });
        return o;
    };

    /**
    * Backbone view model.
    **/
    var searchModel = Backbone.Model.extend({
        defaults: {
            ArrivalDate: moment().format(),
            Duration: 1,
            MinStarRating: 1,
            Adults: 1,
            Children: 0,
            Infants: 0,
            RegionId: 72
        }
    });

    /**
     * Backbone view.
     **/

    window.AppView = Backbone.View.extend({

        el: $(".totalstaybooking"),

        // Main initialization entry point...

        initialize: function () {
            this.initInputForm();
        },

        initInputForm: function () {
            $('select').select2();
            $('#entrydate').datepicker({
                format: "dd-mm-yyyy",
                language: 'en',
                autoclose: true,
                defaultDate: moment().toDate()
            }).on('changeDate', function (ev) {
                $('#entrydate').datepicker('hide');
            });
            $('[title!=""]').qtip({
                style: {
                    classes: 'qtip-dark qtip-shadow qtip-rounded'
                }
            });
            $("#entrydate").datepicker('setDate', moment().toDate());
        },

        // Submit the Speed entry form with a help of WindModel...

        doAvailabilitySearch: function (e) {
            var template,
                dataObj,
                self = this;
            template = '{{#PropertyResult}}<tr><td><b>{{PropertyName}}</b></td><td>{{PropertyID}}</td><td>{{Rating}}</td><td>{{Country}}</td><td>{{Region}}</td><td>{{PropertyReferenceID}}</td>' +
                '<td>{{Resort}}</td><td><input type="button" class="btn btn-small btn-primary" value="select" /></td></tr>{{/PropertyResult}}';
            dataObj = this.$('#RegMetadata').serializeObject();
            $.ajax({
                url: "api/Common/Incident",
                type: "POST",
                data: dataObj,
                success: function (e) {
                    if (e.Response != null) {
                        var htm = Mustache.render(template, e.Response.PropertyResults);
                        self.$("#tbdyHistory").html(htm);
                        console.log(e.Response);
                    }
                },
                error: function (e, o, t) {
                    bootbox.alert(e + "\n" + o + "\n" + t);
                }
            });
            return true;

        },

        // Backbone View events ...

        events: {
            "change #select2-state": "stateSelected",
            "change #select2-city": "populateStationCode",
            "change input.speedTrack": "calculateVariance",
            "click #btnCaptchaRfresh": "generateCaptchaImage",
            "click #registerbtn": "doAvailabilitySearch",
            "click #historicalData": "historicalData",
            "click #expandcollapse": "expandcollpasehistoryblock",

        }

    });

    var appview = new AppView();
});