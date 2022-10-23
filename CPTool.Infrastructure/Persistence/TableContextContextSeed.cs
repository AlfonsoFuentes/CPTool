using CPTool.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.Infrastructure.Persistence
{

    public static class SeedData
    {
        public static void InitializeDatabase(this IServiceProvider service)
        {
            var scopeFactory = service.GetRequiredService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<TableContext>();
                if (!db.Chapters!.Any())
                {
                    AddChapters(db);
                }

                if (!db.MWOTypes!.Any())
                {
                    AddMWOType(db);
                }
                if (!db.MeasuredVariables!.Any())
                {
                    AddMeasuredVariable(db);
                }
                if (!db.MeasuredVariableModifiers!.Any())
                {
                    AddMeasuredVariableModifier(db);
                }
                if (!db.Readouts!.Any())
                {
                    AddReadout(db);
                }
                if (!db.DeviceFunctions!.Any())
                {
                    AddDeviceFunction(db);
                }
                if (!db.DeviceFunctionModifiers!.Any())
                {
                    AddDeviceFunctionModifier(db);
                }
                if(!db.PropertyPackages!.Any())
                {
                    AddPropertyPackage(db);
                }
            }
        }

        static void AddChapters(TableContext context)
        {
            var chapters = new Chapter[]
            {
                new Chapter()
                {    
                    //Id = 1,
                        Name = "Alterations and Other P&L Expense Items",
                        Letter="A"
                },
                new Chapter()
                {
                        //Id = 2,
                        Name = "Foundations",
                        Letter="B"

                },
                new Chapter()
                {
                        //Id = 3,
                        Name = "Structural",
                        Letter="C"
                },
                new Chapter()
                {
                        //Id = 4,
                        Name = "Equipment",
                        Letter="D"
                },
                new Chapter()
                {
                        //Id = 5,
                        Name = "Electrical",
                        Letter="E"
                },
                new Chapter()
                {
                        //Id = 6,
                        Name = "Piping",
                        Letter="F"
                },
                new Chapter()
                {
                        //Id = 7,
                        Name = "Instruments",
                        Letter="G"
                },
                new Chapter()
                {
                        //Id = 8,
                        Name = "Insulation",
                        Letter="H"
                },
                new Chapter()
                {
                        //Id = 9,
                        Name = "Painting",
                        Letter="I"
                },
                new Chapter()
                {
                        //Id = 10,
                        Name = "EOHS",
                        Letter="K"
                },
                new Chapter()
                {
                        //Id = 11,
                        Name = "Taxes/Freight/Insurance/Duties/Consular Fees",
                        Letter="L"
                },
                new Chapter()
                {
                        //Id = 12,
                        Name = "Testing/Inspection/Start-up",
                        Letter="N"
                },
                new Chapter()
                {
                        //Id = 13,
                        Name = "Engineering Cost",
                        Letter="O"
                },
                new Chapter()
                {
                        //Id = 14,
                        Name = "Escalation/Unforseen/Contingency",
                        Letter="P"
                },
            };
            context.Chapters!.AddRange(chapters);

            context.SaveChanges();
        }
        static void AddMWOType(TableContext context)
        {
            var mwotype = new MWOType[]
            {
                new MWOType()
                {    
                    //Id = 1,
                        Name = "SAVINGS",

                },
                new MWOType()
                {
                        //Id = 2,
                        Name = "IMPROVEMENT",

                },
                new MWOType()
                {
                        //Id = 3,
                        Name = "REPLACEMENT",

                },
                new MWOType()
                {
                        //Id = 4,
                        Name = "EHS",

                },

            };
            context.MWOTypes!.AddRange(mwotype);

            context.SaveChanges();
        }

        static void AddMeasuredVariable(TableContext context)
        {
            MeasuredVariable[] variables = new[]
            {
                 new MeasuredVariable()
                 {
                     Name="Analysis",
                     TagLetter="A" ,
                     Description=$"Note 1: \nFirst-letter A (analysis) covers all analyses not described by a 'user's choice' letter."+
                     "\nIt is expected that the type of analysis will be defined outside a tagging bubble"+
                     "\nNote 2: First-letter V, 'vibration or mechanical analysis,' is intended to perform the duties in"+
                        "machinery monitoring that the letter A performs in more general analyses. Except"+
                        "for vibration, it is expected that the variable of interest will be defined outside the"+
                        "tagging bubble"

                 },
                 new MeasuredVariable()
                 {
                     Name="Burner, Combustion",
                     TagLetter="B" ,
                       Description="",

                 },
                 new MeasuredVariable()
                 {
                     Name="User's Choice",
                     TagLetter="C" ,
                     Description=$"A 'user's choice' letter is intended to cover unlisted meanings that will be used"+
                                "repetitively in a particular project. If used, the letter may have one meaning as a firstletter"+
                                "and another meaning as a succeeding-letter. The meanings need to be defined"+
                                "only once in a legend, or other place, for that project. For example, the letter N may"+
                                "be defined as 'modulus of elasticity' as a first - letter and 'oscilloscope' as a"+
                                "succeeding - letter",

                 },
                 new MeasuredVariable()
                 {
                   Name="User's Choice",
                     TagLetter="D" ,
                     Description=$"A 'user's choice' letter is intended to cover unlisted meanings that will be used"+
                                "repetitively in a particular project. If used, the letter may have one meaning as a firstletter"+
                                "and another meaning as a succeeding-letter. The meanings need to be defined"+
                                "only once in a legend, or other place, for that project. For example, the letter N may"+
                                "be defined as 'modulus of elasticity' as a first - letter and 'oscilloscope' as a"+
                                "succeeding - letter",

                 },
                 new MeasuredVariable()
                 {
                     Name="Voltage",
                     TagLetter="E" ,
                     Description="",

                 },
                 new MeasuredVariable()
                 {
                     Name="Flow Rate",
                     TagLetter="F" ,
                     Description="",

                 },
                 new MeasuredVariable()
                 {
                       Name="User's Choice",
                     TagLetter="G" ,
                     Description=$"A 'user's choice' letter is intended to cover unlisted meanings that will be used"+
                                "repetitively in a particular project. If used, the letter may have one meaning as a firstletter"+
                                "and another meaning as a succeeding-letter. The meanings need to be defined"+
                                "only once in a legend, or other place, for that project. For example, the letter N may"+
                                "be defined as 'modulus of elasticity' as a first - letter and 'oscilloscope' as a"+
                                "succeeding - letter",

                 },
                 new MeasuredVariable()
                 {
                     Name="Hand",
                     TagLetter="H" ,
                     Description="",

                 },
                 new MeasuredVariable()
                 {
                     Name="Current (Electrical)",
                     TagLetter="I" ,
                     Description="",

                 },
                 new MeasuredVariable()
                 {
                     Name="Power",
                     TagLetter="J" ,
                     Description="",

                 },
                 new MeasuredVariable()
                 {
                     Name="Time, Time Schedule",
                     TagLetter="K" ,
                     Description="",

                 },
                 new MeasuredVariable()
                 {
                     Name="Level",
                     TagLetter="L" ,
                     Description="",

                 },
                 new MeasuredVariable()
                 {
                     Name="User's Choice",
                     TagLetter="M" ,
                     Description=$"A 'user's choice' letter is intended to cover unlisted meanings that will be used"+
                                "repetitively in a particular project. If used, the letter may have one meaning as a firstletter"+
                                "and another meaning as a succeeding-letter. The meanings need to be defined"+
                                "only once in a legend, or other place, for that project. For example, the letter N may"+
                                "be defined as 'modulus of elasticity' as a first - letter and 'oscilloscope' as a"+
                                "succeeding - letter",

                 },
                 new MeasuredVariable()
                 {
                      Name="User's Choice",
                     TagLetter="N" ,
                     Description=$"A 'user's choice' letter is intended to cover unlisted meanings that will be used"+
                                "repetitively in a particular project. If used, the letter may have one meaning as a firstletter"+
                                "and another meaning as a succeeding-letter. The meanings need to be defined"+
                                "only once in a legend, or other place, for that project. For example, the letter N may"+
                                "be defined as 'modulus of elasticity' as a first - letter and 'oscilloscope' as a"+
                                "succeeding - letter",

                 },
                 new MeasuredVariable()
                 {
                      Name="User's Choice",
                     TagLetter="O" ,
                     Description=$"A 'user's choice' letter is intended to cover unlisted meanings that will be used"+
                                "repetitively in a particular project. If used, the letter may have one meaning as a firstletter"+
                                "and another meaning as a succeeding-letter. The meanings need to be defined"+
                                "only once in a legend, or other place, for that project. For example, the letter N may"+
                                "be defined as 'modulus of elasticity' as a first - letter and 'oscilloscope' as a"+
                                "succeeding - letter",

                 },
                 new MeasuredVariable()
                 {
                     Name="Pressure, Vacuum",
                     TagLetter="P" ,
                     Description="",

                 },
                 new MeasuredVariable()
                 {
                     Name="Quantity",
                     TagLetter="Q" ,
                     Description="",

                 },
                 new MeasuredVariable()
                 {
                     Name="Radiation",
                     TagLetter="R" ,
                     Description="",

                 },
                 new MeasuredVariable()
                 {
                     Name="Speed, Frequency",
                     TagLetter="S" ,
                     Description="",

                 },
                 new MeasuredVariable()
                 {
                     Name="Temperature",
                     TagLetter="T" ,
                     Description="",

                 },
                 new MeasuredVariable()
                 {
                     Name="Multivariable",
                     TagLetter="U" ,
                     Description=$"Use of first-letter U for 'multivariable' in lieu of a combination of first-letters is optional.\n" +
                        "It is recommended that nonspecific variable designators such as U be used sparingly",

                 },
                 new MeasuredVariable()
                 {
                     Name="Vibration, Mechanical Analysis",
                     TagLetter="V" ,
                     Description=$"First-letter V, 'vibration or mechanical analysis,' is intended to perform the duties in"+
                        "machinery monitoring that the letter A performs in more general analyses. Except"+
                        "for vibration, it is expected that the variable of interest will be defined outside the"+
                        "tagging bubble",

                 },
                 new MeasuredVariable()
                 {
                     Name="Weight, Force",
                     TagLetter="W" ,
                     Description="",

                 },
                 new MeasuredVariable()
                 {
                     Name="Unclassified",
                     TagLetter="X" ,
                     Description="The unclassified letter X is intended to cover unlisted meanings that will be used only"+
                        "once or used to a limited extent. If used, the letter may have any number of meanings"+
                        "as a first-letter and any number of meanings as a succeeding-letter. Except for its"+
                        "use with distinctive symbols, it is expected that the meanings will be defined outside"+
                        "a tagging bubble on a flow diagram.For example, XR - 2 may be a stress recorder"+
                        "and XX - 4 may be a stress oscilloscope.",

                 },
                 new MeasuredVariable()
                 {
                     Name="Event, State or Presence",
                     TagLetter="Y" ,
                     Description="First-letter Y is intended for use when control or monitoring responses are eventdriven"+
                    "as opposed to time- or time schedule-driven. The letter Y, in this position, can"+
                    "also signify presence or state",

                 },
                 new MeasuredVariable()
                 {
                     Name="Position, Dimension",
                     TagLetter="Z" ,
                     Description="",

                 },

            };
            context.MeasuredVariables!.AddRange(variables);

            context.SaveChanges();


        }
        static void AddMeasuredVariableModifier(TableContext context)
        {
            MeasuredVariableModifier[] variables = new[]
            {
                 new MeasuredVariableModifier()
                 {
                   Name="Differential",
                     TagLetter="D" ,
                     Description=$"Any first-letter, if used in combination with modifying letters D (differential), F (ratio),"+
                     "M (momentary), K (time rate of change), Q (integrate or totalize), or any combination"+
                     "of these is intended to represent a new and separate measured variable, and the"+
                     "combination is treated as a first-letter entity. Thus, instruments TDI and TI indicate"+
                     "two different variables, namely, differential-temperature and temperature. Modifying"+
                     "letters are used when applicable.",

                 },

                 new MeasuredVariableModifier()
                 {
                     Name="Ratio (Fraction)",
                     TagLetter="F" ,
                    Description=$"Any first-letter, if used in combination with modifying letters D (differential), F (ratio),"+
                     "M (momentary), K (time rate of change), Q (integrate or totalize), or any combination"+
                     "of these is intended to represent a new and separate measured variable, and the"+
                     "combination is treated as a first-letter entity. Thus, instruments TDI and TI indicate"+
                     "two different variables, namely, differential-temperature and temperature. Modifying"+
                     "letters are used when applicable.",

                 },

                 new MeasuredVariableModifier()
                 {
                     Name="Scan",
                     TagLetter="J" ,
                      Description="The use of modifying terms 'high,' 'low,' 'middle' or 'intermediate,' and 'scan' is optional",

                 },
                 new MeasuredVariableModifier()
                 {
                     Name="Time Rate of Change",
                        TagLetter="K" ,
                    Description=$"Note 1:\nAny first-letter, if used in combination with modifying letters D (differential), F (ratio),"+
                     "M (momentary), K (time rate of change), Q (integrate or totalize), or any combination"+
                     "of these is intended to represent a new and separate measured variable, and the"+
                     "combination is treated as a first-letter entity. Thus, instruments TDI and TI indicate"+
                     "two different variables, namely, differential-temperature and temperature. Modifying"+
                     "letters are used when applicable.\n"+
                     "Note 2:\nModifying-letter K, in combination with a first-letter such as L, T, or W, signifies a time"+
                        "rate of change of the measured or initiating variable. The variable WKIC, for instance, "+
                        "may represent a rate - of - weight - loss controller",

                 },

                 new MeasuredVariableModifier()
                 {
                     Name="Momentary",
                     TagLetter="M" ,
                     Description=$"Any first-letter, if used in combination with modifying letters D (differential), F (ratio), M (momentary), K (time rate of change), Q (integrate or totalize), or any combination of these is intended to represent a new and separate measured variable, and the combination is treated as a first-letter entity. Thus, instruments TDI and TI indicate two different variables, namely, differential-temperature and temperature. Modifying letters are used when applicable."

                 },

                 new MeasuredVariableModifier()
                 {
                     Name="Integrate, Totalize",
                     TagLetter="Q" ,
                    Description=$"Any first-letter, if used in combination with modifying letters D (differential), F (ratio), M (momentary), K (time rate of change), Q (integrate or totalize), or any combination of these is intended to represent a new and separate measured variable, and the combination is treated as a first-letter entity. Thus, instruments TDI and TI indicate two different variables, namely, differential-temperature and temperature. Modifying letters are used when applicable."


                 },

                 new MeasuredVariableModifier()
                 {
                     Name="Safety",
                     TagLetter="S" ,
                     Description="The term 'safety' applies to emergency protective primary elements and emergency"+
"protective final control elements only. Thus, a self-actuated valve that prevents"+
"operation of a fluid system at a higher-than-desired pressure by bleeding fluid from"+
"the system is a back-pressure-type PCV, even if the valve is not intended to be used"+
"normally.However, this valve is designated as a PSV if it is intended to protect against"+
"emergency conditions, i.e., conditions that are hazardous to personnel and / or"+
"equipment and that are not expected to arise normally, The designation PSV applies to all valves intended to protect against emergency" +
"pressure conditions regardless of whether the valve construction and mode of operation"+
"place them in the category of the safety valve, relief valve, or safety relief"+
"valve. A rupture disc is designated PSE"

                 },

                 new MeasuredVariableModifier()
                 {
                     Name="X Axis",
                     TagLetter="X" ,
                     Description="",

                 },
                 new MeasuredVariableModifier()
                 {
                     Name="Y Axis",
                     TagLetter="Y" ,
                     Description="",

                 },
                 new MeasuredVariableModifier()
                 {
                     Name="Z Axis",
                     TagLetter="Z" ,
                     Description="",

                 },

            };


            context.MeasuredVariableModifiers!.AddRange(variables);

            context.SaveChanges();
        }
        static void AddReadout(TableContext context)
        {
            Readout[] variables = new[]
            {
                 new Readout()
                 {
                     Name="Alarm",
                     TagLetter="A" ,
                     Description=$""

                 },
                 new Readout()
                 {
                     Name="User's Choice",
                     TagLetter="B" ,
                       Description=$"A 'user's choice' letter is intended to cover unlisted meanings that will be used"+
                                "repetitively in a particular project. If used, the letter may have one meaning as a firstletter"+
                                "and another meaning as a succeeding-letter. The meanings need to be defined"+
                                "only once in a legend, or other place, for that project. For example, the letter N may"+
                                "be defined as 'modulus of elasticity' as a first - letter and 'oscilloscope' as a"+
                                "succeeding - letter"

                 },

                 new Readout()
                 {
                     Name="Sensor (Primary Element)",
                     TagLetter ="E" ,
                     Description="",

                 },

                 new Readout()
                 {
                       Name="Glass, Viewing Device",
                     TagLetter="G" ,
                     Description=$"The passive function G applies to instruments or devices that provide an uncalibrated view, such as sight glasses and television monitors",

                 },

                 new Readout()
                 {
                     Name="Indicate",
                     TagLetter="I" ,
                     Description="'Indicate' normally applies to the readout—analog or digital—of an actual measurement."+
                     " In the case of a manual loader, it may be used for the dial or setting"+
                        "indication, i.e., for the value of the initiating variable.",

                 },

                 new Readout()
                 {
                     Name="Light",
                     TagLetter="L" ,
                     Description="A pilot light that is part of an instrument loop should be designated by a first-letter"+
                    "followed by the succeeding-letter L. For example, a pilot light that indicates an expired"+
                    "time period should be tagged KQL. If it is desired to tag a pilot light that is not part"+
                    "of an instrument loop, the light is designated in the same way. For example, a running"+
                    "light for an electric motor may be tagged EL, assuming voltage to be the appropriate"+
                    "measured variable, or YL, assuming the operating status is being monitored. The"+
                    "unclassified variable X should be used only for applications which are limited in extent."+
                    "The designation XL should not be used for motor running lights, as these are"+
                    "commonly numerous.It is permissible to use the user's choice letters M, N or O for"+
                    "a motor running light when the meaning is previously defined. If M is used, it must"+
                    "be clear that the letter does not stand for the word 'motor,' but for a monitored state",

                 },

                 new Readout()
                 {
                      Name="User's Choice",
                     TagLetter="N" ,
                     Description=$"A 'user's choice' letter is intended to cover unlisted meanings that will be used"+
                                "repetitively in a particular project. If used, the letter may have one meaning as a firstletter"+
                                "and another meaning as a succeeding-letter. The meanings need to be defined"+
                                "only once in a legend, or other place, for that project. For example, the letter N may"+
                                "be defined as 'modulus of elasticity' as a first - letter and 'oscilloscope' as a"+
                                "succeeding - letter",

                 },
                 new Readout()
                 {
                      Name="Orifice, Restriction",
                     TagLetter="O" ,
                     Description=$"",

                 },
                 new Readout()
                 {
                     Name="Point (Test) Connection",
                     TagLetter="P" ,
                     Description="",

                 },

                 new Readout()
                 {
                     Name="Record",
                     TagLetter="R" ,
                     Description="The word 'record' applies to any form of permanent storage of information that permits"+
                    "retrieval by any means.",

                 },

                 new Readout()
                 {
                     Name="Multifunction",
                     TagLetter="U" ,
                     Description=$"Use of a succeeding-letter U for 'multifunction' instead of a combination of other"+
                "functional letters is optional. This nonspecific function designator should be used"+
                "sparingly"

                 },

                 new Readout()
                 {
                     Name="Well",
                     TagLetter="W" ,
                     Description="",

                 },
                 new Readout()
                 {
                     Name="Unclassified",
                     TagLetter="X" ,
                     Description="The unclassified letter X is intended to cover unlisted meanings that will be used only"+
                    "once or used to a limited extent. If used, the letter may have any number of meanings"+
                    "as a first-letter and any number of meanings as a succeeding-letter. Except for its"+
                    "use with distinctive symbols, it is expected that the meanings will be defined outside"+
                    "a tagging bubble on a flow diagram.For example, XR - 2 may be a stress recorder"+
                    "and XX - 4 may be a stress oscilloscope",

                 },


            };

            context.Readouts!.AddRange(variables);

            context.SaveChanges();
        }
        static void AddDeviceFunction(TableContext context)
        {
            DeviceFunction[] variables = new[]
            {

                 new DeviceFunction()
                 {
                      Name="User's Choice",
                     TagLetter="B" ,
                      Description=$"A 'user's choice' letter is intended to cover unlisted meanings that will be used"+
                                "repetitively in a particular project. If used, the letter may have one meaning as a firstletter"+
                                "and another meaning as a succeeding-letter. The meanings need to be defined"+
                                "only once in a legend, or other place, for that project. For example, the letter N may"+
                                "be defined as 'modulus of elasticity' as a first - letter and 'oscilloscope' as a"+
                                "succeeding - letter",

                 },
                  new DeviceFunction()
                 {
                      Name="Control",
                     TagLetter="C" ,
                      Description=$"A device that connects, disconnects, or transfers one or more circuits may be either"+
                        "a switch, a relay, an ON - OFF controller, or a control valve, depending on the"+
                                                "application"+" \nIf the device manipulates a fluid process stream and is not a hand-actuated ON-OFF block"+
                        "valve, it is designated as a control valve. It is incorrect to use the succeeding-letters CV"+
                        "for anything other than a self - actuated control valve.For all applications other than fluid"+
                        "process streams, the device is designated as follows:"+
                        "\n• A switch, if it is actuated by hand."+
                        "\n• A switch or an ON-OFF controller, if it is automatic and is the first such device in a loop."+
                        "The term 'switch' is generally used if the device is used for alarm, pilot light, selection, "+
                        "interlock, or safety." +
                        "\n• The term 'controller' is generally used if the device is used for normal operating control."+
                        "\n• A relay, if it is automatic and is not the first such device in a loop, i.e., it is actuated by a" +
                        "switch or an ON-OFF controller. ",

                 },
                 new DeviceFunction()
                 {
                     Name="Control Station",
                     TagLetter="K" ,
                     Description="Succeeding-letter K is a user's option for designating a control station, while the"+
                        "succeeding-letter C is used for describing automatic or manual controllers",

                 },

                 new DeviceFunction()
                 {
                      Name="User's Choice",
                     TagLetter="N" ,
                     Description=$"A 'user's choice' letter is intended to cover unlisted meanings that will be used"+
                                "repetitively in a particular project. If used, the letter may have one meaning as a firstletter"+
                                "and another meaning as a succeeding-letter. The meanings need to be defined"+
                                "only once in a legend, or other place, for that project. For example, the letter N may"+
                                "be defined as 'modulus of elasticity' as a first - letter and 'oscilloscope' as a"+
                                "succeeding - letter",

                 },

                 new DeviceFunction()
                 {
                     Name="Switch",
                     TagLetter="S" ,
                     Description="A device that connects, disconnects, or transfers one or more circuits may be either"+
                        "a switch, a relay, an ON - OFF controller, or a control valve, depending on the"+
                                                "application"+" \nIf the device manipulates a fluid process stream and is not a hand-actuated ON-OFF block"+
                        "valve, it is designated as a control valve. It is incorrect to use the succeeding-letters CV"+
                        "for anything other than a self - actuated control valve.For all applications other than fluid"+
                        "process streams, the device is designated as follows:"+
                        "\n• A switch, if it is actuated by hand."+
                        "\n• A switch or an ON-OFF controller, if it is automatic and is the first such device in a loop."+
                        "The term 'switch' is generally used if the device is used for alarm, pilot light, selection, "+
                        "interlock, or safety." +
                        "\n• The term 'controller' is generally used if the device is used for normal operating control."+
                        "\n• A relay, if it is automatic and is not the first such device in a loop, i.e., it is actuated by a" +
                        "switch or an ON-OFF controller. ",

                 },
                 new DeviceFunction()
                 {
                     Name="Transmitter",
                     TagLetter="T" ,
                     Description="For use of the term 'transmitter' versus 'converter,'",

                 },
                 new DeviceFunction()
                 {
                     Name="Multifunction",
                     TagLetter="U" ,
                     Description=$"Use of a succeeding-letter U for 'multifunction' instead of a combination of other"+
                        "functional letters is optional. This nonspecific function designator should be used"+
                        "sparingly"

                 },
                 new DeviceFunction()
                 {
                     Name="Valve, Damper, Louver",
                     TagLetter="V" ,
                     Description=$"A device that connects, disconnects, or transfers one or more circuits may be either"+
                    "a switch, a relay, an ON - OFF controller, or a control valve, depending on the"+
                    "application",

                 },
                 new DeviceFunction()
                 {
                     Name="Unclassified",
                     TagLetter="X" ,
                     Description="The unclassified letter X is intended to cover unlisted meanings that will be used only"+
                        "once or used to a limited extent. If used, the letter may have any number of meanings"+
                        "as a first-letter and any number of meanings as a succeeding-letter. Except for its"+
                        "use with distinctive symbols, it is expected that the meanings will be defined outside"+
                        "a tagging bubble on a flow diagram.For example, XR - 2 may be a stress recorder"+
                        "and XX - 4 may be a stress oscilloscope.",

                 },
                 new DeviceFunction()
                 {
                     Name="Relay, Compute, Convert",
                     TagLetter="Y" ,
                     Description=
                     "Note 1: \nA device that connects, disconnects, or transfers one or more circuits may be either"+
                        "a switch, a relay, an ON - OFF controller, or a control valve, depending on the"+
                                                "application"+" \nIf the device manipulates a fluid process stream and is not a hand-actuated ON-OFF block"+
                        "valve, it is designated as a control valve. It is incorrect to use the succeeding-letters CV"+
                        "for anything other than a self - actuated control valve.For all applications other than fluid"+
                        "process streams, the device is designated as follows:"+
                        "\n• A switch, if it is actuated by hand."+
                        "\n• A switch or an ON-OFF controller, if it is automatic and is the first such device in a loop."+
                        "The term 'switch' is generally used if the device is used for alarm, pilot light, selection, "+
                        "interlock, or safety." +
                        "\n• The term 'controller' is generally used if the device is used for normal operating control."+
                        "\n• A relay, if it is automatic and is not the first such device in a loop, i.e., it is actuated by a" +
                        "switch or an ON-OFF controller. "+
                     "Note 2: \n It is expected that the functions associated with the use of succeeding-letter Y will be" +
                        "defined outside a bubble on a diagram when further definition is considered" +
                        "necessary. This definition need not be made when the function is self-evident, as for" +
                        "a solenoid valve in a fluid signal line."  +
                     "Note 3: \n For use of the term 'transmitter' versus 'converter,'",

                 },
                 new DeviceFunction()
                 {
                     Name="Driver, Actuator, Unclassified Final Control Element",
                     TagLetter="Z" ,
                     Description="",

                 },

            };


            context.DeviceFunctions!.AddRange(variables);

            context.SaveChanges();
        }
        static void AddDeviceFunctionModifier(TableContext context)
        {
            DeviceFunctionModifier[] variables = new[]
            {

                 new DeviceFunctionModifier()
                 {
                     Name="User's Choice",
                     TagLetter="B" ,
                    Description=$"A 'user's choice' letter is intended to cover unlisted meanings that will be used"+
                                "repetitively in a particular project. If used, the letter may have one meaning as a firstletter"+
                                "and another meaning as a succeeding-letter. The meanings need to be defined"+
                                "only once in a legend, or other place, for that project. For example, the letter N may"+
                                "be defined as 'modulus of elasticity' as a first - letter and 'oscilloscope' as a"+
                                "succeeding - letter",

                 },

                 new DeviceFunctionModifier()
                 {
                     Name="High",
                     TagLetter="H" ,
                     Description=
                     "Note 1: \n The use of modifying terms 'high,' 'low,' 'middle' or 'intermediate,' and 'scan' is optional"+
                     "Note 2: \n The modifying terms 'high,' and 'low,' and 'middle' or 'intermediate' correspond to"+
                        "values of the measured variable, not to values of the signal, unless otherwise noted."+
                        "For example, a high-level alarm derived from a reverse-acting level transmitter signal "+
                        "should be an LAH, even though the alarm is actuated when the signal falls to a low "+
                        "value. The terms may be used in combinations as appropriate"+
                     "Note 3: \nThe terms 'high' and 'low,' when applied to positions of valves and other open-close "+
                        "devices, are defined as follows: 'high' denotes that the valve is in or approaching the"+
                        "fully open position, and 'low' denotes that it is in or approaching the fully closed"+
                        "position",

                 },

                 new DeviceFunctionModifier()
                 {
                     Name="Low",
                     TagLetter="L" ,
                     Description=
                     "Note 1: \n The use of modifying terms 'high,' 'low,' 'middle' or 'intermediate,' and 'scan' is optional"+
                     "Note 2: \n The modifying terms 'high,' and 'low,' and 'middle' or 'intermediate' correspond to"+
                        "values of the measured variable, not to values of the signal, unless otherwise noted."+
                        "For example, a high-level alarm derived from a reverse-acting level transmitter signal "+
                        "should be an LAH, even though the alarm is actuated when the signal falls to a low "+
                        "value. The terms may be used in combinations as appropriate"+
                     "Note 3: \nThe terms 'high' and 'low,' when applied to positions of valves and other open-close "+
                        "devices, are defined as follows: 'high' denotes that the valve is in or approaching the"+
                        "fully open position, and 'low' denotes that it is in or approaching the fully closed"+
                        "position",

                 },
                 new DeviceFunctionModifier()
                 {
                     Name="Middle, Intermediate",
                     TagLetter="M" ,
                     Description= "Note 1: \n The use of modifying terms 'high,' 'low,' 'middle' or 'intermediate,' and 'scan' is optional"+
                     "Note 2: \n The modifying terms 'high,' and 'low,' and 'middle' or 'intermediate' correspond to"+
                        "values of the measured variable, not to values of the signal, unless otherwise noted."+
                        "For example, a high-level alarm derived from a reverse-acting level transmitter signal "+
                        "should be an LAH, even though the alarm is actuated when the signal falls to a low "+
                        "value. The terms may be used in combinations as appropriate",

                 },
                 new DeviceFunctionModifier()
                 {
                      Name="User's Choice",
                     TagLetter="N" ,
                     Description=$"A 'user's choice' letter is intended to cover unlisted meanings that will be used"+
                                "repetitively in a particular project. If used, the letter may have one meaning as a firstletter"+
                                "and another meaning as a succeeding-letter. The meanings need to be defined"+
                                "only once in a legend, or other place, for that project. For example, the letter N may"+
                                "be defined as 'modulus of elasticity' as a first - letter and 'oscilloscope' as a"+
                                "succeeding - letter",

                 },

                 new DeviceFunctionModifier()
                 {
                     Name="Multifunction",
                     TagLetter="U" ,
                    Description=$"Use of a succeeding-letter U for 'multifunction' instead of a combination of other"+
                        "functional letters is optional. This nonspecific function designator should be used"+
                        "sparingly"

                 },
                 new DeviceFunctionModifier()
                 {
                     Name="Valve, Damper, Louver",
                     TagLetter="V" ,
                     Description=$"A device that connects, disconnects, or transfers one or more circuits may be either"+
                    "a switch, a relay, an ON - OFF controller, or a control valve, depending on the"+
                    "application",

                 },
                 new DeviceFunctionModifier()
                 {
                     Name="Unclassified",
                     TagLetter="X" ,
                     Description="The unclassified letter X is intended to cover unlisted meanings that will be used only"+
                        "once or used to a limited extent. If used, the letter may have any number of meanings"+
                        "as a first-letter and any number of meanings as a succeeding-letter. Except for its"+
                        "use with distinctive symbols, it is expected that the meanings will be defined outside"+
                        "a tagging bubble on a flow diagram.For example, XR - 2 may be a stress recorder"+
                        "and XX - 4 may be a stress oscilloscope.",

                 },


            };


            context.DeviceFunctionModifiers!.AddRange(variables);

            context.SaveChanges();
        }
        static void AddPropertyPackage(TableContext context)
        {
            PropertyPackage[] variables = new[]
            {

                 new PropertyPackage()
                 {
                     Name="Water",

                 },




            };


            context.PropertyPackages!.AddRange(variables);

            context.SaveChanges();
        }
    }
}