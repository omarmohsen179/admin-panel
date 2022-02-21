import REQUEST from "../../Services/Request";

export const STEPS = async (e, status) => {
  return await REQUEST({
    method: "get",
    url: "Steps/admin",
  });
};
export const STEPS_INSERT = async (e) => {
  return await REQUEST({
    method: "post",
    url: "Steps",
    data: e,
  });
};
export const STEPS_UPDATE = async (e) => {
  return await REQUEST({
    method: "put",
    url: "Steps",
    data: e,
  });
};
export const STEPS_DELETE = async (id) => {
  return await REQUEST({
    method: "delete",
    url: "/Benefits/" + id,
  });
};

export const BENEFITS = async (e, status) => {
  return await REQUEST({
    method: "get",
    url: "/Benefits/admin",
  });
};
export const BENEFITS_INSERT = async (e) => {
  return await REQUEST({
    method: "post",
    url: "Benefits",
    data: e,
  });
};
export const BENEFITS_UPDATE = async (e) => {
  return await REQUEST({
    method: "put",
    url: "Benefits",
    data: e,
  });
};
export const BENEFITS_DELETE = async (id) => {
  return await REQUEST({
    method: "delete",
    url: "Benefits/" + id,
  });
};
export const MEMBER = async (e, status) => {
  return await REQUEST({
    method: "get",
    url: "/Member/admin",
  });
};
export const MEMBER_INSERT = async (e) => {
  return await REQUEST({
    method: "post",
    url: "Member",
    data: e,
  });
};
export const MEMBER_UPDATE = async (e) => {
  return await REQUEST({
    method: "put",
    url: "Member",
    data: e,
  });
};
export const MEMBER_DELETE = async (id) => {
  return await REQUEST({
    method: "delete",
    url: "Member/" + id,
  });
};
export const SECTION_PAGE = async (page) => {
  return await REQUEST({
    method: "get",
    url: "Section/" + page,
  });
};
export const SECTION_UPDATE = async (e) => {
  return await REQUEST({
    method: "put",
    url: "Section",
    data: e,
  });
};
