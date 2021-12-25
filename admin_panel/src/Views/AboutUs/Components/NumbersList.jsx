import { useCallback } from "react";

import { FormGroup, Input, Button } from "reactstrap";
import InputTwoLanguages from "../../../Components/InputTwoLanguages/InputTwoLanguages";
import notify from "devextreme/ui/notify";
import { useTranslation } from "react-i18next";
import { NUMBER_DELETE } from "../AboutUs.Api";
import LabeledInput from "../../../Components/Inputs/LabeledInput";

const NumbersList = ({ data, setdata }) => {
  const { t, i18n } = useTranslation();

  let Delete = useCallback(
    async (element) => {
      if (element > 0) {
        await NUMBER_DELETE(element)
          .then(() => {
            let dataAfterDelete = data.filter(function (el) {
              return el.Id !== element;
            });

            setdata(dataAfterDelete);
            notify(
              { message: "Deleted Successfully", width: 600 },
              "success",
              3000
            );
          })
          .catch(() => {
            notify({ message: "Failed Try again", width: 600 }, "error", 3000);
          });
      } else {
        setdata(
          data.filter(function (el) {
            return el.Id !== element;
          })
        );
      }
    },
    [data, setdata]
  );

  let HandleChange = useCallback(
    (Id, value, name) => {
      setdata(
        data.map((da) => {
          if (da.Id === Id) {
            return { ...da, [name]: value };
          }
          return da;
        })
      );
    },
    [data, setdata]
  );

  return (
    <>
      <div style={{ direction: i18n.language === "en" ? "ltr" : "rtl" }}>
        {data &&
          data.map((da) => {
            return (
              <div>
                <div>
                  <div className="row">
                    <div className="col">
                      <FormGroup>
                        <LabeledInput
                          Label="Phone Number"
                          value={da.PhoneNumber}
                          HandleChange={(name, value) =>
                            HandleChange(da.Id, name, value)
                          }
                          name="PhoneNumber"
                        />
                      </FormGroup>
                    </div>
                    <div className="col number-list-delete-button ">
                      <Button
                        className="btn btn btn-danger col-12"
                        onClick={() => Delete(da.Id)}
                        // disabled={da.id <= 0}
                        //  onClick={Dele}
                      >
                        -
                      </Button>
                    </div>
                  </div>
                </div>
              </div>
            );
          })}
      </div>
    </>
  );
};

export default NumbersList;
