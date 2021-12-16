import notify from "devextreme/ui/notify";
import { useCallback, useEffect, useRef, useState } from "react";
import CardForm from "../../../Components/CardForm/CardForm";
import PopUpModel from "../../../Components/PopUpModel/PopUpModel";
import YesOrNoPopUp from "../../../Components/YesOrNoPopUp/YesOrNoPopUp";
import { STEPS, STEPS_DELETE, STEPS_INSERT, STEPS_UPDATE } from "../Home.Api";
import "../Home.css";
import StepsForm from "./StepsForm";
function Steps() {
  let [data, setdata] = useState([]);
  let defualtValues = useRef({
    Id: 0,
    Title: "",
    TitleEn: "",
    Description: "",
    DescriptionEn: "",
    Active: false,
  });
  let [YesOrNo, setYesOrNo] = useState({ id: 0, state: false });
  let [popup, setpopup] = useState({ data: {}, status: false });
  useEffect(() => {
    STEPS()
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
    await STEPS_DELETE(id)
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

  let objectKeysToLowerCase = function (input) {
    if (typeof input !== "object") return input;
    if (Array.isArray(input)) return input.map(objectKeysToLowerCase);
    return Object.keys(input).reduce(function (newObj, key) {
      let val = input[key];
      let newVal =
        typeof val === "object" && val !== null
          ? objectKeysToLowerCase(val)
          : val;
      newObj[key.toLowerCase()] = newVal;
      return newObj;
    }, {});
  };
  const OnSubmit = useCallback(
    async (id) => {
      if (popup.data.Id == 0) {
        await STEPS_INSERT(popup.data)
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
        await STEPS_UPDATE(popup.data)
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
      <CardForm title=" Steps">
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
            <div key={index} className="Home-steps-card">
              <div
                onClick={() => setpopup({ data: res, status: !popup.status })}
                className="  number-circle"
              >
                <div className="step-circle">
                  <p> {index + 1}</p>
                </div>
              </div>
              <div
                onClick={() => setpopup({ data: res, status: !popup.status })}
                className="col"
              >
                <div className="step-card-title">{res.Title}</div>
                <div>{res.Description}</div>
              </div>
              <div
                className="delete-icon-crud"
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
        <StepsForm
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

export default Steps;
