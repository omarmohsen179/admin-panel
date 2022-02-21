import notify from "devextreme/ui/notify";
import { useCallback, useEffect, useRef, useState } from "react";
import CardForm from "../../../Components/CardForm/CardForm";
import PopUpModel from "../../../Components/PopUpModel/PopUpModel";
import YesOrNoPopUp from "../../../Components/YesOrNoPopUp/YesOrNoPopUp";
import {
  BENEFITS,
  BENEFITS_DELETE,
  BENEFITS_INSERT,
  BENEFITS_UPDATE,
} from "../Home.Api";
import "../Home.css";
import BenefitsForm from "./BenefitsForm";

import { ApiBaseUrl } from "../../../Services/config.json";
function Benefits() {
  let [data, setdata] = useState([]);
  let defualtValues = useRef({
    Id: 0,
    Title: "",
    TitleEn: "",
    Description: "",
    DescriptionEn: "",
    ImagePath: "",
    Image: null,
    Active: false,
  });
  let [YesOrNo, setYesOrNo] = useState({ id: 0, state: false });
  let [popup, setpopup] = useState({ data: {}, status: false });
  useEffect(async () => {
    await BENEFITS()
      .then((res) => {
        setdata(res);
      })
      .catch(() => {});
  }, []);
  const OnDelete = useCallback(async (id) => {
    if (id <= 0) {
      notify("Error in information. select Again! ");
      return;
    }
    await BENEFITS_DELETE(id)
      .then(() => {
        let x = data.filter(function (el) {
          return el.Id !== id;
        });
        setdata(x);
        notify("Deleted successfuly", "success", 3000);
      })
      .catch(() => {
        notify("Error in information. try again! ", "error", 3000);
      });
  }, []);

  const OnSubmit = useCallback(
    async (id) => {
      let formData = new FormData();

      for (let [key, value] of Object.entries(popup.data)) {
        formData.append(key.toString(), value);
      }
      if (popup.data.Id == 0) {
        await BENEFITS_INSERT(formData)
          .then((res) => {
            notify("Added successfuly", "success", 3000);
            data.push(res);
            setdata(data);
            setpopup({ data: {}, status: false });
          })
          .catch(() => {
            notify("Error in information. try again! ", "error", 3000);
          });
      } else {
        await BENEFITS_UPDATE(formData)
          .then((res) => {
            notify("Updated successfuly", "success", 3000);
            setdata(
              data.map((ele) => {
                return ele.Id == popup.data.Id ? { ...res } : { ...ele };
              })
            );
            setpopup({ data: {}, status: false });
          })
          .catch(() => {
            notify("Error in information. try again! ", "error", 3000);
          });
      }
    },
    [popup.data]
  );

  return (
    <div>
      <CardForm title=" Benefits">
        <div
          className="Add-icon-form "
          onClick={() =>
            setpopup({ data: defualtValues.current, status: !popup.status })
          }
        >
          <i className="far fa-plus-square"></i>
        </div>
        {data.map((res, index) => {
          return (
            <div key={index} className="row Home-benefits-card">
              <div
                onClick={() => setpopup({ data: res, status: !popup.status })}
                className="col-md-3 col-lg-2 col-sm-6  number-circle"
              >
                <div
                  style={{ width: "100%", height: "200%" }}
                  className="step-benefit"
                >
                  <img
                    src={ApiBaseUrl + res.ImagePath}
                    width="100%"
                    height="100"
                  />
                </div>
              </div>
              <div
                onClick={() => setpopup({ data: res, status: !popup.status })}
                className="col-lg-8 col-md-7 col-sm-4"
              >
                <div className="step-card-title">{res.TitleEn}</div>
                <div>{res.DescriptionEn}</div>
              </div>
              <div
                className="col-lg-2 col-md-2 col-sm-2 delete-icon-crud"
                onClick={() => setYesOrNo({ id: res.Id, state: true })}
              >
                <i className=" fas fa-trash-alt"></i>
              </div>
            </div>
          );
        })}
      </CardForm>
      <PopUpModel
        setdialog={(e) => setpopup({ ...popup, status: e })}
        dailog={popup.status}
        Submit={OnSubmit}
      >
        <BenefitsForm
          data={popup.data}
          setdata={(e) => setpopup({ ...popup, data: e })}
        />
      </PopUpModel>
      <YesOrNoPopUp
        dailog={YesOrNo}
        setdialog={(e) => setYesOrNo({ ...popup, state: e })}
        OnDelete={OnDelete}
      />
    </div>
  );
}

export default Benefits;
