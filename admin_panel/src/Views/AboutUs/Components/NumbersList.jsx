import { useCallback } from "react";

import { FormGroup, Input, Button } from "reactstrap";
import InputTwoLanguages from "../../../Components/InputTwoLanguages/InputTwoLanguages";
import notify from "devextreme/ui/notify";
import { useTranslation } from "react-i18next";
import { NUMBER_DELETE } from "../AboutUs.Api";

const NumbersList = ({ data, setdata }) => {
  const { t, i18n } = useTranslation();

  let Delete = useCallback(
    async (element) => {
      if (element > 0) {
        await NUMBER_DELETE(element)
          .then(() => {
            setdata(
              data.filter(function (el) {
                return el.id !== element;
              })
            );
            notify(
              { message: t("Deleted Successfully"), width: 600 },
              "success",
              3000
            );
          })
          .catch(() => {
            notify(
              { message: t("Failed Try again"), width: 600 },
              "error",
              3000
            );
          });
      } else {
        setdata(
          data.filter(function (el) {
            return el.id !== element;
          })
        );
      }
    },
    [data, t, setdata]
  );

  let HandleChange = useCallback(
    (id, value, name) => {
      setdata(
        data.map((da) => {
          if (da.id === id) {
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
                        <InputTwoLanguages
                          id="title"
                          label={t("Title")}
                          onValueChange={(n, v) => HandleChange(da.id, n, v)}
                          value={da.title}
                          valueEn={da.titleEn}
                        />
                      </FormGroup>
                    </div>
                  </div>

                  <div
                    className="row"
                    style={{ display: "flex", justifyContent: "center" }}
                  >
                    <div className="col">
                      <Button
                        className="btn btn btn-danger col-12"
                        onClick={() => Delete(da.id)}
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
