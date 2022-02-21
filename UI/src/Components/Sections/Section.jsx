import React, { useCallback } from "react";
import { FormGroup } from "reactstrap";
import SubmitButtons from "../Buttons/SubmitButtons";
import CardForm from "../CardForm/CardForm";
import InputTwoLanguages from "../InputTwoLanguages/InputTwoLanguages";
import UploadImageButton from "../UploadImageButton/UploadImageButton";
import { ApiBaseUrl } from "../../Services/config.json";
import notify from "devextreme/ui/notify";
import { SECTION_UPDATE } from "../../Views/Home/Home.Api";
function Section({ data, HandleChange, setdata, submit }) {
  let handleGetImages = (event) => {
    let files = event.target.files;
    setdata(data.Id, files[0]);
  };
  const Submit = useCallback(
    async (e) => {
      let formData = new FormData();

      for (let [key, value] of Object.entries(data)) {
        if (key != "Text" && key != "Image") {
          formData.append(key.toString(), value);
        }
      }
      formData.append("Text", JSON.stringify(data.Text));
      formData.append("Image", JSON.stringify(data.Image));
      await SECTION_UPDATE(formData)
        .then((res) => {
          submit(res);
          notify("Updated successfuly", "success", 3000);
        })
        .catch(() => {
          notify("Error in information. try again! ", "error", 3000);
        });
    },
    [data]
  );
  let handleRemoveImage = useCallback(() => {
    setdata(data.Id, "");
  }, [data]);

  return (
    <CardForm onSubmit={Submit} title=" Text Section ">
      <div>
        {data?.Text &&
          data.Text?.map((ele) => {
            return (
              <FormGroup>
                <InputTwoLanguages
                  id="Content"
                  label={ele.Title}
                  onValueChange={(name, value) =>
                    HandleChange(data.Id, ele.Id, name, value)
                  }
                  value={ele?.Content}
                  valueEn={ele?.ContentEn}
                />
              </FormGroup>
            );
          })}
        {data?.Image ? (
          <FormGroup className="image__button">
            <label>{"Image"} </label>
            <UploadImageButton
              isMultiple={false}
              handleGetImages={handleGetImages}
              handleRemoveImage={handleRemoveImage}
              imagesFiles={
                data?.Image?.ImagePath || data?.Imageup
                  ? [
                      data?.Image.ImagePath
                        ? ApiBaseUrl + data?.Image?.ImagePath
                        : data?.Imageup,
                    ]
                  : []
              }
            />
          </FormGroup>
        ) : null}
      </div>
      <SubmitButtons />
    </CardForm>
  );
}

export default Section;
